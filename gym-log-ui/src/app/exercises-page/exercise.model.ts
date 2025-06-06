export class Exercise {
  constructor(
    public exerciseId: number,
    public exerciseName: string,
    public exerciseCategoryId: number,
    public bodyPartId: number,
    public estimatedOneRepMax: number
  ) {}

  static fromJson(json: any): Exercise {
    return new Exercise(
      json.exerciseId,
      json.exerciseName,
      json.exerciseCategoryId,
      json.bodyPartId,
      json.estimatedOneRepMax
    );
  }
}