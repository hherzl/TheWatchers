export class CardModel {
  public id!: number;
  public resource!: string;
  public resourceCategory!: string;
  public environment!: string;
  public successful!: boolean;
  public watchCount!: number;
  public lastWatch!: Date;
  public cols!: number;
  public rows!: number;
}
