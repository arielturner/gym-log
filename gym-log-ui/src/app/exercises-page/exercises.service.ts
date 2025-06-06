import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Exercise } from './exercise.model';

@Injectable({
  providedIn: 'root'
})
export class ExercisesService {
  private http = inject(HttpClient);
  private apiUrl = environment.apiUrl;

  constructor() { }

  getExercisesByBodyPart(bodyPartId: number) {
    return this.http.get<Exercise[]>(`${this.apiUrl}/exercises?bodyPartId=${bodyPartId}`);
  }
}
