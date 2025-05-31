export class BodyPart {
  constructor(
    public bodyPartId: number,
    public bodyPartName: string
  ) {}

  static fromJson(json: any): BodyPart {
    return new BodyPart(
      json.bodyPartId,
      json.bodyPartName
    );
  }
}