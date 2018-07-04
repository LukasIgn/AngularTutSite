export class SnackDetail {
    id: number;
    details: string;
  
    constructor(values: Object = {}) {
      Object.assign(this, values);
    }
}
