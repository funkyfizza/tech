import PropTypes from "prop-types";

const CatFactShape = PropTypes.shape({
    Id: PropTypes.string.isRequired,
    Timestamp: PropTypes.string.isRequired,
    Fact: PropTypes.string.isRequired,
    Comments: PropTypes.arrayOf(PropTypes.shape({

    })),
    Ratings: PropTypes.arrayOf(PropTypes.shape({

    })),
});

export default CatFactShape;
