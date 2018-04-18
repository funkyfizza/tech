import { get } from "../api";
import meta, {API_RATING_DATA} from "../meta";
import { dummyInputRatings, dummyInputUsers, dummyResult } from "./meta.fixtures";
import { API_USER_DATA } from "../meta";

const apiCalls = {
    [API_USER_DATA]: dummyInputUsers,
    [API_RATING_DATA]: dummyInputRatings,
};

jest.mock("../api");
get.mockImplementation(url => Promise.resolve(apiCalls[url]));

describe("meta api", () => {
    it("should produce the expected result", async () => {
        const result = await meta();
        expect(result).toMatchObject(dummyResult);
    });
});
