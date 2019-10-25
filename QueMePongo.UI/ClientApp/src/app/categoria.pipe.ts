import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'Categoria'
})
export class CategoriaPipe implements PipeTransform {

  transform(color: number): string {
    if (color == 1) return "Cabeza";
    if (color == 2) return "Torso";
    if (color == 3) return "Piernas";
    if (color == 4) return "Pies";
    if (color == 5) return "Accesorio";
  }

}
