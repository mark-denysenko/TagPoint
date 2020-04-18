import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AppListComponent } from "./list.component";
import { AppInputTextModule } from "src/app/components/input/text/text.module";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";

const routes: Routes = [
    { path: "", component: AppListComponent }
];

@NgModule({
    declarations: [AppListComponent],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forChild(routes),
        AppInputTextModule
    ],
    exports: [RouterModule]
})
export class AppListModule { }
