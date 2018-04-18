import React from "react";
import { timeDisplay } from "Helpers/time";
import "./index.css";

const CatFactHistory = ({ item }) => (
    <div className="CatFactHistory">
        <div className="CatFactHistoryCommentList">
            {item.Comments.map(comment => (
                <div key={comment.Id} className="CatFactHistoryComment">
                    <div className="CatFactHistoryTimestamp">
                        {timeDisplay(comment.Timestamp)}
                    </div>
                    <div>{comment.Comment}</div>
                </div>
            ))}
        </div>
        <div className="CatFactHistoryRatingList">
            {item.Ratings.map(rating => (
                <div key={rating.Id} className="CatFactHistoryRating">
                    <div className="CatFactHistoryTimestamp">
                        {timeDisplay(rating.Timestamp)}
                    </div>
                    <div className="CatFactRatingStars">
                        {[1,2,3,4,5].map((r, i) => r <= rating.Rating
                            ? <span key={i} className="StarFilled">★</span>
                            : <span key={i} className="StarEmpty">☆</span>)}
                    </div>
                </div>
            ))}
        </div>
    </div>
);

export default CatFactHistory;
