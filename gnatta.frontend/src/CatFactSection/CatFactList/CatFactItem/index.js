import React from "react";
import PropTypes from "prop-types";
import { timeDisplay } from "Helpers/time";
import CatFactShape from "../../CatFactShape";
import "./index.css"

const getCommentMeta = fact => `(${fact.Comments.length} comments)`;
const getRatingMeta = fact => {
    if (fact.Ratings.length === 0) {
        return "(0 ratings)"
    }

    const tot = fact.Ratings.reduce((tot, cur) => tot + cur.Rating, 0);
    const avg = tot / fact.Ratings.length;
    return `(${avg}/5 with ${fact.Ratings.length} ratings)`;
};

const CatFactItem = ({ onClick, fact, isSelected }) => (
    <div className={`CatFactItem${isSelected ? " CatFactItemSelected" : ""}`} onClick={onClick}>
        <div className="CatFactItemTitle">
            {fact.Id}
        </div>
        <div className="CatFactItemMeta">
            {timeDisplay(fact.Timestamp)} {getCommentMeta(fact)} {getRatingMeta(fact)}
        </div>
        <div className="CatFactItemText">
            {fact.Fact}
        </div>
    </div>
);

CatFactItem.propTypes = {
    fact: CatFactShape,
    onClick: PropTypes.func.isRequired,
};

export default CatFactItem;
