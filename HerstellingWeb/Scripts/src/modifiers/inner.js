import getClientRect from "../utils/getClientRect";
import getOppositePlacement from "../utils/getOppositePlacement";

/**
 * @function
 * @memberof Modifiers
 * @argument {Object} data - The data object generated by `update` method
 * @argument {Object} options - Modifiers configuration and options
 * @returns {Object} The data object, properly modified
 */
export default function inner(data) {
    const placement = data.placement;
    const basePlacement = placement.split("-")[0];
    const { popper, reference } = data.offsets;
    const isHoriz = ["left", "right"].indexOf(basePlacement) !== -1;

    const subtractLength = ["top", "left"].indexOf(basePlacement) === -1;

    popper[isHoriz ? "left" : "top"] =
        reference[basePlacement] -
        (subtractLength ? popper[isHoriz ? "width" : "height"] : 0);

    data.placement = getOppositePlacement(placement);
    data.offsets.popper = getClientRect(popper);

    return data;
}