import { Attribute } from "./attribute";
import { Image } from "./image";
import { UnitOfMeasure } from "./unitOfMeasure";

export interface Item {
  itemName: string;
  itemDescription: string;
  category: string;
  categoryDescription: string;
  parentCategory: string;
  parentCategoryDescription: string;
  unitQuantity: number;
  upc: string;

  attributes: Attribute[];
  unitOfMeasure: UnitOfMeasure;
  images: Image[];
}
