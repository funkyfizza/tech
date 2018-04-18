import React from "react";
import NoItemSelected from "./NoItemSelected";
import CatFactEditor from "./CatFactEditor";
import "./index.css";

const CatFactDisplay = ({ item, onCommentAdded }) => (
    <div className="CatFactDisplay">
        {item
            ? <CatFactEditor item={item} onCommentAdded={onCommentAdded} />
            : <NoItemSelected />
        }
    </div>
);

export default CatFactDisplay;
