import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'Color'
})
export class ColorPipe implements PipeTransform {

  transform(color:number): string {
    if (color == 1) return "Azul";
    if (color == 2) return "Rojo";
    if (color == 3) return "Negro";
    if (color == 4) return "Blanco";
    if (color == 5) return "Verde";
    if (color == 6) return "Marron";
  }

}
