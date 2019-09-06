import { UserAC } from './UserAC';
import { ReviewCommentAC } from './ReviewCommentAC';

export class ReviewAC {
        //public Review:Review 
        //public ReviewLike ReviewLike { get; set; }
        //public ReviewComment Comment { get; set; }
        //public ICollection < ReviewComment > ReviewComment { get; set; }

  //************************************************************
  reviewId: number;
  rating: number;
  reviewText: string;
  totalLike: number;
  userAC: UserAC;
  reviewCommnets: ReviewCommentAC[];
  restaurantId: number;
  showComment: boolean = false;

}
