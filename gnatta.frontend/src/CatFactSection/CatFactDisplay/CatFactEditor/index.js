import React from "react";
import PropTypes from "prop-types";
import CatFactShape from "../../CatFactShape";
import CatFactAddComment from "./CatFactAddComment";
import CatFactHistory from "./CatFactHistory";
import "./index.css";

const CatFactEditor = ({ item, onCommentAdded }) => (
    <div className="CatFactEditor">
        <div>
            <b>Id:</b> {item.Id}
        </div>
        <div>
            <b>Created:</b> {new Date(item.Timestamp).toLocaleString()}
        </div>
        <div>
            <b>Rating:</b>
        </div>
        <div className="CatFactEditorDisplayText">
            {item.Fact}
        </div>
        <CatFactAddComment item={item} onCommentAdded={onCommentAdded} />
        <CatFactHistory item={item} />
    </div>
);

CatFactEditor.propTypes = {
    item: CatFactShape.isRequired,
    onCommentAdded: PropTypes.func.isRequired,
};

export default CatFactEditor;
