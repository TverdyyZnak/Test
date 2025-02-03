import { Routes } from '@angular/router';
import { BookPageComponent } from './components/book-page/book-page.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import { LoginPageComponent } from './components/login-page/login-page.component';
import { RegPageComponent } from './components/reg-page/reg-page.component';
import { CatalogPageComponent } from './components/catalog-page/catalog-page.component';
import { AuthorsPageComponent } from './components/authors-page/authors-page.component';
import { AccountPageComponent } from './components/account-page/account-page.component';
import { AddPageComponent } from './components/add-page/add-page.component';
import { UpdatePageComponent } from './components/update-page/update-page.component';

export const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full'},
    { path: 'home' , component: HomePageComponent},
    { path: 'book-info/:id', component: BookPageComponent},
    { path: 'login', component:LoginPageComponent},
    { path: 'registration', component: RegPageComponent},
    { path: 'catalog', component: CatalogPageComponent},
    { path: 'authors', component: AuthorsPageComponent},
    { path: 'account', component: AccountPageComponent},
    { path: 'add-book', component: AddPageComponent},
    { path: 'update-book', component: UpdatePageComponent}
];
