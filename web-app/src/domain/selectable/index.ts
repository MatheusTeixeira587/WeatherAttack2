export class Selectable {
  public name: { en_us: String, pt_br: String }
  public value: number;

  constructor(name: {en_us: string, pt_br: string}, value: number)
  {
    this.name = name;
    this.value = value;
  }
}

export class WeatherCondition extends Selectable {}
export class Operator extends Selectable{}
export class Element extends Selectable{}
