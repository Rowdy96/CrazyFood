import { UserAC } from './UserAC';
import { ReviewCommentAC } from './ReviewCommentAC';

export class ReviewAC {
  ReviewId: number;
  Rating: number;
  ReviewText: string;
  TotalLike: number;
  TotalComment: number;
  UserAC: UserAC;
  ReviewCommnets: ReviewCommentAC[];
  RestaurantId: number;
  RestaurantName: string;
  ShowComment: boolean = false;

}
