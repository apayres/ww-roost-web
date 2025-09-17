import { Attributes } from "./attributes";
import { UnitOfMeasure } from "./unitOfMeasure";

export interface Item {
  id: string;
  itemName: string;
  itemDescription: string;
  category: string;
  categoryDescription: string;
  parentCategory: string;
  parentCategoryDescription: string;
  unitQuantity: number;
  upc: string;
  itemAttributes: Attributes;
  unitOfMeasure: UnitOfMeasure;
  imageUrl: string;
}
