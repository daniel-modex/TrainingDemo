import { Routes } from '@angular/router';
import { FirstComponent } from './components/first/first.component';
import { SecondComponent } from './components/second/second.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { ChildAComponent } from './components/first/child-a/child-a.component';
import { ChildBComponent } from './components/first/child-b/child-b.component';

export const routes: Routes = [
    {
        path: 'first-component', component: FirstComponent,
        children: [
            { path: '', redirectTo: 'child-a', pathMatch: 'full' },
            { path: 'child-a', component: ChildAComponent },
            { path: 'child-b', component: ChildBComponent },
        ],
    },
    { path: 'second-component', component: SecondComponent },
    { path: '', redirectTo: 'first-component', pathMatch: 'full' },
    { path: '**', component: PageNotFoundComponent },
];
