const express = require('express');
const http = require('http');
const {Server} = require('socket.io');
const wrtc = require('wrtc');

const app = express();
const server = http.createServer(app);
const io = new Server(server, {cors : {origin : '*'}});

let broadcaster = null;
let viewers = new Set();

io.on('connection', (socket) => console.log('a user connected', socket.id));

socket.on('broadcaster', async (offer) => {
    console.log('new broadcaster', socket.id);
    broadcaster = socket;
    viewers.clear();

    const peerConnection = new wrtc.RTCPeerConnection();

    peerConnection.ontrack = (event) => {
        event.streams[0].getTracks().forEach((track) => {
            viewers.forEach((viewer) => {
                viewer.peerConnection.addTrack(track, event.streams[0]);
            })
        })
    }

})