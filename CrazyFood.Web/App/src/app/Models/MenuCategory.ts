import { Restaurant } from './Restaurant';

export class MenuCategory {
  id: number;
  menuCategoryName: string;
  totalDishes: number;
  restaurantId: number;
  restaurant: Restaurant;
}
