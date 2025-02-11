const express = require('express');
const http = require('http');
const { Server } = require('socket.io');
const wrtc = require('wrtc');

const app = express();
const server = http.createServer(app);
const io = new Server(server, { cors: { origin: '*' } });

let broadcaster = null;
const viewers = new Map(); 

io.on('connection', (socket) => {
    console.log('A user connected:', socket.id);

    socket.on('broadcaster', async (offer) => {
        console.log('New broadcaster:', socket.id);
        broadcaster = socket;
        viewers.clear();

        const peerConnection = new wrtc.RTCPeerConnection();
        
        peerConnection.ontrack = (event) => {
            event.streams[0].getTracks().forEach((track) => {
                viewers.forEach((viewer) => {
                    viewer.peerConnection.addTrack(track, event.streams[0]);
                });
            });
        };

        await peerConnection.setRemoteDescription(new wrtc.RTCSessionDescription(offer));
        const answer = await peerConnection.createAnswer();
        await peerConnection.setLocalDescription(answer);

        socket.emit('broadcasterAnswer', peerConnection.localDescription);
    });

    socket.on('viewer', async (offer) => {
        if (!broadcaster) {
            socket.emit('error', 'No broadcaster available');
            return;
        }

        console.log('New viewer:', socket.id);
        const peerConnection = new wrtc.RTCPeerConnection();
        viewers.set(socket.id, { peerConnection });

        broadcaster.emit('viewerOffer', { offer, viewerId: socket.id });

        socket.on('disconnect', () => {
            viewers.delete(socket.id);
            console.log('Viewer disconnected:', socket.id);
        });
    });

    socket.on('broadcasterAnswerViewer', async ({ answer, viewerId }) => {
        const viewer = viewers.get(viewerId);
        if (viewer) {
            await viewer.peerConnection.setRemoteDescription(new wrtc.RTCSessionDescription(answer));
            console.log(`Broadcaster answered viewer ${viewerId}`);
        }
    });

    socket.on('disconnect', () => {
        console.log('User disconnected:', socket.id);
        if (socket === broadcaster) {
            broadcaster = null;
            viewers.clear();
            console.log('Broadcaster left, clearing viewers');
        } else {
            viewers.delete(socket.id);
        }
    });
});

server.listen(3000, () => console.log('Server running on port 3000'));
