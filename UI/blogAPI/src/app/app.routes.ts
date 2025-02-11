import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home/home.component';
import { SearchComponent } from './components/blogs/search/search.component';
import { CategorySelectorComponent } from './components/blogs/category-selector/category-selector.component';
import { EditBlogComponent } from './components/blogs/edit-blog/edit-blog.component';
import { BlogWriteComponent } from './components/blogs/blog-write/blog-write.component';
import { LoginComponent } from './components/auth/login/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { authGuard } from './components/auth/auth.guard';
import { AppComponent } from './app.component';
import { WelcomeComponent } from './components/welcome/welcome.component';
import { BlogDetailsComponent } from './components/blogs/blog-details/blog-details.component';
import { TopBlogsComponent } from './components/blogs/top-blogs/top-blogs.component';
import { BoomarkFolderListComponent } from './components/bookmark/boomark-folder-list/boomark-folder-list.component';
import { BookmarkFolderContentsComponent } from './components/bookmark/bookmark-folder-contents/bookmark-folder-contents.component';
import { TopRankingBlogsComponent } from './components/achievements/top-ranking-blogs/top-ranking-blogs.component';
import { TopUsersComponent } from './components/achievements/top-users/top-users.component';
import { PersonalAchievementsComponent } from './components/achievements/personal-achievements/personal-achievements.component';
import { FeedComponent } from './components/forum/feed/feed.component';
import { ForumCategoryFeedComponent } from './components/forum/forum-category-feed/forum-category-feed.component';
import { CommunityFeedComponent } from './components/forum/community-feed/community-feed.component';

export const routes: Routes = [
    { path: '', pathMatch: 'full', redirectTo: 'home' },  
    //{ path: 'home', component: HomeComponent, canActivate: [authGuard], data: { roles: ['user'] } },
    { path: 'home', component: HomeComponent},
    { path: 'blogs/:id', component: BlogDetailsComponent, pathMatch: 'full' },

    { path: 'myBlogs/:slug/edit', component: EditBlogComponent },
    { path: 'write', component: BlogWriteComponent },
    { path: 'login', component: WelcomeComponent, pathMatch: 'full' },
    { path: 'register', component: WelcomeComponent, pathMatch: 'full' },
    {path: 'bookmarks', component: BoomarkFolderListComponent},
    {path: 'bookmarks/:id', component: BookmarkFolderContentsComponent},
    {path: 'achievements/top-ranking-blogs', component: TopRankingBlogsComponent},
    {path: 'achievements/top-ranking-users', component: TopUsersComponent},
    {path: 'achievements', component: PersonalAchievementsComponent},
    {path: 'forum/feed', component: FeedComponent},
    {path: 'forum/category/:id', component: ForumCategoryFeedComponent},
    {path: 'forum/community/:id', component: CommunityFeedComponent},

];

export default RouterModule.forRoot(routes, {onSameUrlNavigation: 'reload'});

