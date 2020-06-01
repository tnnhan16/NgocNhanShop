export class ResponseError {
  key: string
  value: string
  constructor(data: ResponseError) {
    this.key = data.key;
    this.value = data.value;
  }
}
