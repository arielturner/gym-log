import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SortService {

  constructor() { }

  /**
   * Sorts an array of objects by a specified column.
   * @param data - The array of objects to sort.
   * @param column - The column name to sort by.
   * @param ascending - Whether to sort in ascending order (default is true).
   * @returns A new array sorted by the specified column.
   */
  sortBy(data: any[], column: string, ascending: boolean = true): any[] {
    return data.sort((a, b) => {
      const valueA = (a as any)[column];
      const valueB = (b as any)[column];

      if (ascending) {
        return valueA > valueB ? 1 : -1;
      } else {
        return valueA > valueB ? -1 : 1;
      }
    });
  }
}
