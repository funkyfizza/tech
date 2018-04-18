import React, { Component } from "react";
import PropTypes from "prop-types";
import { changeHandler } from "Helpers/state";
import { post } from "Helpers/api";
import "./index.css";

class CatFactAddComment extends Component {
    constructor(props) {
        super(props);
        this.state = { commentInput: "" };

        this.handleChange = changeHandler(this, "commentInput");
        this.addComment = this.addComment.bind(this);
    }

    addComment() {
        const { item, onCommentAdded } = this.props;
        const { commentInput } = this.state;

        this.setState({ commentInput: "" });

        post(`/fact/${item.Id}/comment`, commentInput).then(comment => {
            onCommentAdded(item, comment);
        });
    }

    render() {
        const { commentInput } = this.state;
        const canSubmit = commentInput.trim().length > 0;
        return (
            <div className="CatFactEditorAddComment">
                <form onSubmit={this.addComment}>
                    <textarea
                        placeholder="Add comment"
                        value={commentInput}
                        onChange={this.handleChange}
                        maxLength={200}
                    />
                    <button
                        disabled={!canSubmit}
                        onClick={this.addComment}
                        type="submit"
                    >
                        Add Comment
                    </button>
                </form>
            </div>
        );
    }
}

CatFactAddComment.propTypes = {
    onCommentAdded: PropTypes.func.isRequired,
};

export default CatFactAddComment;
