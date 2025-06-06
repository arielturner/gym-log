import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

import { BodyPart } from './body-part.model';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BodyPartsService {
  private http = inject(HttpClient);
  private apiUrl = environment.apiUrl;

  constructor() { }

  getBodyParts() {
    return this.http.get<BodyPart[]>(`${this.apiUrl}/body-parts`);
  }
}
