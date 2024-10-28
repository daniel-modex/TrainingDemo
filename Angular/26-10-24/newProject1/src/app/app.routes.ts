import { Routes } from '@angular/router';
import { ListComponent } from './component/list/list.component';
import { UpdateComponent } from './component/update/update.component';
import { AddNewComponent } from './component/add-new/add-new.component';
import { DeleteComponent } from './component/delete/delete.component';
import { DetailsComponent } from './component/details/details.component';

export const routes: Routes = [
    {path:'list',component:ListComponent},
    {path:'update',component:UpdateComponent},
    {path:'add-new',component:AddNewComponent},
    {path:'delete',component:DeleteComponent},
    {path:'details',component:DetailsComponent},
    {path:'',redirectTo:'/',pathMatch:'full'},
];
