import React from "react";
import PropTypes from "prop-types";
import CatFactShape from "../CatFactShape";
import EmptyList from "./EmptyList";
import CatFactItem  from "./CatFactItem";
import "./index.css";

const CatFactList = ({ onItemClick, list, item }) => (
    <div className="CatFactList">
        {list.length < 1
            ? <EmptyList />
            : list.map(fact => (
                <CatFactItem
                    key={fact.Id}
                    fact={fact}
                    isSelected={fact === item}
                    onClick={() => onItemClick(fact)}
                />
            ))
        }
    </div>
);

CatFactList.propTypes = {
    list: PropTypes.arrayOf(CatFactShape).isRequired,
    item: CatFactShape,
    onItemClick: PropTypes.func.isRequired,
};

CatFactList.defaultProps = {
    item: null,
};

export default CatFactList;
