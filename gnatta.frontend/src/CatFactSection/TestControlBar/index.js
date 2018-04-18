import React from "react";
import PropTypes from "prop-types";
import "./index.css";

const TestControlBar = ({ disableButtons, onDeleteAllClick, onUploadClick }) => (
    <div className="TestControlBar">
        <button onClick={onDeleteAllClick} disabled={disableButtons}>Delete All</button>
        <button onClick={onUploadClick} disabled={disableButtons}>Upload Fact</button>
    </div>
);

TestControlBar.propTypes = {
    disableButtons: PropTypes.bool.isRequired,
    onDeleteAllClick: PropTypes.func.isRequired,
    onUploadClick: PropTypes.func.isRequired,
};

export default TestControlBar;
