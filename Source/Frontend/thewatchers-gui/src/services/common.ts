export class ListResponse<TModel> {
  public model!: TModel[];
}

export class SingleResponse<TModel> {
  public model!: TModel;
}

export class CreatedResponse<TId> {
  public id!: TId;
}

export class ListItem<TId> {
  public id!: TId;
  public name!: string;
}
