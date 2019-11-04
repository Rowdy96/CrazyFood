import { Restaurant } from './Restaurant';

export class MenuCategory {
  Id: number;
  MenuCategoryName: string;
  TotalDishes: number;
  RestaurantId: number;
  Restaurant: Restaurant;
}
