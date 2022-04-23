import { fromString, Auto_generateBoxedDecoder_79988AEF } from "../fable_modules/Thoth.Json.7.0.0/Decode.fs.js";
import { Universal_Detail$2$reflection, DND5e_CharacterSheet$reflection, ADND2nd_CharacterSheet$reflection } from "../../Lib/Character.fs.js";
import { array_type } from "../fable_modules/fable-library.3.6.2/Reflection.js";
import { uncurry } from "../fable_modules/fable-library.3.6.2/Util.js";
import { toString, Auto_generateBoxedEncoder_Z20B7B430 } from "../fable_modules/Thoth.Json.7.0.0/Encode.fs.js";

export const PCs_key = "PCs";

export function PCs_read() {
    const fallback = new Array(0);
    try {
        const str = window.localStorage[PCs_key];
        let matchValue;
        const decoder = Auto_generateBoxedDecoder_79988AEF(array_type(Universal_Detail$2$reflection(ADND2nd_CharacterSheet$reflection(), DND5e_CharacterSheet$reflection())), void 0, void 0);
        matchValue = fromString(uncurry(2, decoder), str);
        if (matchValue.tag === 1) {
            const err = matchValue.fields[0];
            return fallback;
        }
        else {
            const result = matchValue.fields[0];
            return result;
        }
    }
    catch (matchValue_1) {
        return fallback;
    }
}

export function PCs_write(v) {
    let encoder;
    window.localStorage[PCs_key]=((encoder = Auto_generateBoxedEncoder_Z20B7B430(array_type(Universal_Detail$2$reflection(ADND2nd_CharacterSheet$reflection(), DND5e_CharacterSheet$reflection())), void 0, void 0, void 0), toString(0, encoder(v))));
}

export const Graveyard_key = "Graveyard";

export function Graveyard_read() {
    const fallback = new Array(0);
    try {
        const str = window.localStorage[Graveyard_key];
        let matchValue;
        const decoder = Auto_generateBoxedDecoder_79988AEF(array_type(Universal_Detail$2$reflection(ADND2nd_CharacterSheet$reflection(), DND5e_CharacterSheet$reflection())), void 0, void 0);
        matchValue = fromString(uncurry(2, decoder), str);
        if (matchValue.tag === 1) {
            const err = matchValue.fields[0];
            return fallback;
        }
        else {
            const result = matchValue.fields[0];
            return result;
        }
    }
    catch (matchValue_1) {
        return fallback;
    }
}

export function Graveyard_write(v) {
    let encoder;
    window.localStorage[Graveyard_key]=((encoder = Auto_generateBoxedEncoder_Z20B7B430(array_type(Universal_Detail$2$reflection(ADND2nd_CharacterSheet$reflection(), DND5e_CharacterSheet$reflection())), void 0, void 0, void 0), toString(0, encoder(v))));
}

//# sourceMappingURL=LocalStorage.fs.js.map
