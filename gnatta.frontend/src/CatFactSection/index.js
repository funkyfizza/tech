import React, { Component } from "react";
import { get, post, del } from "Helpers/api";
import CatFactList from "./CatFactList";
import CatFactDisplay from "./CatFactDisplay";
import TestControlBar from "./TestControlBar";
import "./index.css";

export class CatFactSection extends Component {
    constructor(props) {
        super(props);
        this.state = {
            loading: true,
            list: [],
            selectedId: null,
        };

        this.loadFacts = this.loadFacts.bind(this);
        this.uploadNewFact = this.uploadNewFact.bind(this);
        this.deleteAllFacts = this.deleteAllFacts.bind(this);
        this.addComment = this.addComment.bind(this);
    }

    componentDidMount() {
        this.load(this.loadFacts);
    }

    uploadNewFact() {
        this.load(() => post("/upload").then(this.loadFacts));
    }

    deleteAllFacts() {
        this.load(() => del("/fact").then(this.loadFacts));
    }

    selectItem(fact) {
        this.setState({
            selectedId: this.state.selectedId === fact.Id ? null : fact.Id,
        });
    }

    addComment(fact, comment) {
        const { list } = this.state;
        const index = list.indexOf(fact);
        this.setState({
            list: [
                ...list.slice(0, index),
                {
                    ...fact,
                    Comments: fact.Comments.concat([comment]),
                },
                ...list.slice(index + 1)
            ],
        });
    }

    loadFacts() {
        get("/fact").then(result =>
            this.setState({
                loading: false,
                list: result,
            })
        );
    }

    load(callback) {
        this.setState({ loading: true }, callback);
    }

    render() {
        const { loading, selectedId, list } = this.state;
        const item = list.find(x => x.Id === selectedId);
        return (
            <div className="CatFactSection">
                <TestControlBar
                    disableButtons={loading}
                    onDeleteAllClick={this.deleteAllFacts}
                    onUploadClick={this.uploadNewFact}
                />
                <div className="CatFactContainer">
                    <CatFactList
                        list={list}
                        item={item}
                        onItemClick={fact => this.selectItem(fact)}
                    />
                    <CatFactDisplay
                        item={item}
                        onCommentAdded={this.addComment}
                    />
                </div>
            </div>
        );
    }
}



export default CatFactSection;
