import { MatchFailureException, Record } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Types.js";
import { record_type, option_type, list_type, int32_type, lambda_type, bool_type, string_type } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Reflection.js";
import { $007CWord$007C_$007C, $007CLongestSubstringWhere$007C_$007C, pack, ExternalContextOf } from "../Parsing.fs.js";
import { singleton, cons, head, tail, isEmpty, tryPick } from "../../ShiningSword/fable_modules/fable-library.3.6.2/List.js";
import { String_equalsIgnoreCase } from "../Common.fs.js";
import { Lazy } from "../../ShiningSword/fable_modules/fable-library.3.6.2/Util.js";

export class RosterAdaptor extends Record {
    constructor(isValidNamePrefix, tryNamePrefix, tryId, tryName) {
        super();
        this.isValidNamePrefix = isValidNamePrefix;
        this.tryNamePrefix = tryNamePrefix;
        this.tryId = tryId;
        this.tryName = tryName;
    }
}

export function RosterAdaptor$reflection() {
    return record_type("Domain.Parse.Ribbit.RosterAdaptor", [], RosterAdaptor, () => [["isValidNamePrefix", lambda_type(string_type, bool_type)], ["tryNamePrefix", lambda_type(string_type, list_type(int32_type))], ["tryId", lambda_type(int32_type, option_type(string_type))], ["tryName", lambda_type(string_type, option_type(int32_type))]]);
}

export const $007CRoster$007C_$007C = (tupledArg) => ExternalContextOf(tupledArg[0], tupledArg[1]);

export const $007CValidName$007C_$007C = pack((_arg1) => {
    const activePatternResult47774 = $007CRoster$007C_$007C(_arg1);
    if (activePatternResult47774 != null) {
        const ctx = _arg1;
        const roster = activePatternResult47774;
        const activePatternResult47773 = $007CLongestSubstringWhere$007C_$007C(roster.isValidNamePrefix, 30, ctx[0], ctx[1]);
        if (activePatternResult47773 != null) {
            const ctx_1 = activePatternResult47773[1];
            const name = activePatternResult47773[0];
            const matchValue = roster.tryNamePrefix(name);
            let pattern_matching_result, id, matches;
            if (!isEmpty(matchValue)) {
                if (isEmpty(tail(matchValue))) {
                    pattern_matching_result = 0;
                    id = head(matchValue);
                }
                else {
                    pattern_matching_result = 1;
                    matches = matchValue;
                }
            }
            else {
                pattern_matching_result = 1;
                matches = matchValue;
            }
            switch (pattern_matching_result) {
                case 0: {
                    return [id, ctx_1];
                }
                case 1: {
                    return tryPick((id_1) => {
                        let v;
                        const matchValue_1 = roster.tryId(id_1);
                        let pattern_matching_result_1;
                        if (matchValue_1 != null) {
                            if ((v = matchValue_1, String_equalsIgnoreCase(v, name))) {
                                pattern_matching_result_1 = 0;
                            }
                            else {
                                pattern_matching_result_1 = 1;
                            }
                        }
                        else {
                            pattern_matching_result_1 = 1;
                        }
                        switch (pattern_matching_result_1) {
                            case 0: {
                                return [id_1, ctx_1];
                            }
                            case 1: {
                                return void 0;
                            }
                        }
                    }, matches);
                }
            }
        }
        else {
            return void 0;
        }
    }
    else {
        return void 0;
    }
});

export function $007CEventDefinition$007C_$007C(_arg1_0, _arg1_1) {
    const activePatternResult47776 = $007CWord$007C_$007C([_arg1_0, _arg1_1]);
    if (activePatternResult47776 != null) {
        const ctx = activePatternResult47776[1];
        const word = activePatternResult47776[0];
        return void 0;
    }
    else {
        throw (new MatchFailureException("C:/code/ShiningSword/src/Lib/Ribbit/Parse.fs", 68, 70));
    }
}

export function $007CSupplyValue$007C_$007C(_arg1_0, _arg1_1) {
    const activePatternResult47778 = $007CWord$007C_$007C([_arg1_0, _arg1_1]);
    if (activePatternResult47778 != null) {
        const ctx = activePatternResult47778[1];
        const word = activePatternResult47778[0];
        return void 0;
    }
    else {
        throw (new MatchFailureException("C:/code/ShiningSword/src/Lib/Ribbit/Parse.fs", 70, 66));
    }
}

export function $007CStatementsExecute$007C_$007C(_arg1_0, _arg1_1) {
    const activePatternResult47780 = $007CWord$007C_$007C([_arg1_0, _arg1_1]);
    if (activePatternResult47780 != null) {
        const ctx = activePatternResult47780[1];
        const word = activePatternResult47780[0];
        return void 0;
    }
    else {
        throw (new MatchFailureException("C:/code/ShiningSword/src/Lib/Ribbit/Parse.fs", 72, 72));
    }
}

export function $007CCommand$007C_$007C(_arg1_0, _arg1_1) {
    const _arg1 = [_arg1_0, _arg1_1];
    let pattern_matching_result, cmd, ctx;
    const activePatternResult47782 = $007CEventDefinition$007C_$007C(_arg1[0], _arg1[1]);
    if (activePatternResult47782 != null) {
        pattern_matching_result = 0;
        cmd = activePatternResult47782[0];
        ctx = activePatternResult47782[1];
    }
    else {
        const activePatternResult47783 = $007CSupplyValue$007C_$007C(_arg1[0], _arg1[1]);
        if (activePatternResult47783 != null) {
            pattern_matching_result = 0;
            cmd = activePatternResult47783[0];
            ctx = activePatternResult47783[1];
        }
        else {
            const activePatternResult47784 = $007CStatementsExecute$007C_$007C(_arg1[0], _arg1[1]);
            if (activePatternResult47784 != null) {
                pattern_matching_result = 0;
                cmd = activePatternResult47784[0];
                ctx = activePatternResult47784[1];
            }
            else {
                pattern_matching_result = 1;
            }
        }
    }
    switch (pattern_matching_result) {
        case 0: {
            return [cmd, ctx];
        }
        case 1: {
            return void 0;
        }
    }
}

function $007CProgram$007C_$007C$004081$002D2() {
    return pack((_arg1) => {
        let pattern_matching_result, cmd, cmds, ctx;
        const activePatternResult47787 = $007CCommand$007C_$007C(_arg1[0], _arg1[1]);
        if (activePatternResult47787 != null) {
            const activePatternResult47788 = $007CProgram$007C_$007C$004081$002D3.Value(activePatternResult47787[1]);
            if (activePatternResult47788 != null) {
                pattern_matching_result = 0;
                cmd = activePatternResult47787[0];
                cmds = activePatternResult47788[0];
                ctx = activePatternResult47788[1];
            }
            else {
                pattern_matching_result = 1;
            }
        }
        else {
            pattern_matching_result = 1;
        }
        switch (pattern_matching_result) {
            case 0: {
                return [cons(cmd, cmds), ctx];
            }
            case 1: {
                const activePatternResult47786 = $007CCommand$007C_$007C(_arg1[0], _arg1[1]);
                if (activePatternResult47786 != null) {
                    const cmd_1 = activePatternResult47786[0];
                    const ctx_1 = activePatternResult47786[1];
                    return [singleton(cmd_1), ctx_1];
                }
                else {
                    throw (new MatchFailureException("C:/code/ShiningSword/src/Lib/Ribbit/Parse.fs", 82, 12));
                }
            }
        }
    });
}

const $007CProgram$007C_$007C$004081$002D3 = new Lazy($007CProgram$007C_$007C$004081$002D2);

export const $007CProgram$007C_$007C = $007CProgram$007C_$007C$004081$002D3.Value;

//# sourceMappingURL=Parse.fs.js.map
