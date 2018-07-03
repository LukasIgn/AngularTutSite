export class Snack {
    id: number;
    name: string;
    email: string;
    type: string;
  
    constructor(values: Object = {}) {
      Object.assign(this, values);
    }
  }