import React, { Component } from "react";
import Header from "../Header";
import Footer from "../Footer";
import CatFactSection from "../CatFactSection";
import "./index.css";

class App extends Component {
  render() {
    return (
      <div className="App">
          <Header />
          <CatFactSection />
          <Footer />
      </div>
    );
  }
}

export default App;
