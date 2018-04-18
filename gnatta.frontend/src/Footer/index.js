import React, { Component } from "react";
import meta from "../Helpers/meta";
import "./index.css";

class Footer extends Component {
    constructor(props) {
        super(props);
        this.state = { loading: true };
    }

    async componentDidMount() {
        const data = await meta();
        this.setState({ ...data, loading: false });
    }

    render() {
        if (this.state.loading) {
            return <div className="Footer">&#9676;</div>;
        }

        return (
           <div className="Footer">
               <span className="LeaderList">
                   Leaders:
                   {this.state.leaderBoard.map((x, i) => (
                       <span key={i} className={"Leader" + (i === 0 ? " LeaderTop": "")}>
                           [{x.name}: {x.ratings}]
                       </span>
                   ))}
               </span>
               <span>
                   Total Ratings: {this.state.totalRatings} (avg: {this.state.averageRating})
               </span>
           </div>
        );
    }
}

export default Footer;
