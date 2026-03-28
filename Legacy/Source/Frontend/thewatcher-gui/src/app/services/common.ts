export class Response {
}

export class ListResponse<TModel> extends Response {
    public model!: TModel[];
}
