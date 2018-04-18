import { get } from "./api";
import { dummyResult } from "./_test/meta.fixtures"; // TEMP RESULT

export const API_USER_DATA = "/meta/users";
export const API_RATING_DATA = "/meta/ratings";

export default () => Promise.resolve(dummyResult);

/**
 * Expected data structure
 {
    leaderBoard: [
        { id: 1, name: "User 1", ratings: 1 },
        { id: 2, name: "User 2", ratings: 1 },
    ],
    totalRatings: 1,
    averageRating: 1,
 }
 */