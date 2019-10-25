import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'Tela'
})
export class TelaPipe implements PipeTransform {

  transform(color: number): string {
    if (color == 1) return "Cuero";
    if (color == 2) return "Seda";
    if (color == 3) return "Algodon";
    if (color == 4) return "Blanco";
    if (color == 5) return "Jena";
    if (color == 6) return "Lona";
  }

}
