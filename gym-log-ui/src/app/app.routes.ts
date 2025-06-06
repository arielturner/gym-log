import { Routes } from '@angular/router';
import { HomePageComponent } from './home-page/home-page.component';
import { BodyPartsPageComponent } from './body-parts-page/body-parts-page.component';
import { ExercisesPageComponent } from './exercises-page/exercises-page.component';

export const routes: Routes = [
  {
    path: '',
    component: HomePageComponent
  },
  {
    path: 'body-parts',
    component: BodyPartsPageComponent
  },
  {
    path: 'exercises',
    component: ExercisesPageComponent
  }
];
