import { toString, Record, Union } from "../fable_modules/fable-library.3.6.2/Types.js";
import { View_ChargenMethod, View_Msg, View_Ruleset, View_init, View_view, View_update, View_Msg$reflection, View_Model$reflection } from "./Chargen.fs.js";
import { view, stillAlive as stillAlive_1, update, init, Msg$reflection, Model$reflection } from "./Adventure.fs.js";
import { int32_type, bool_type, lambda_type, record_type, array_type, option_type, string_type, union_type } from "../fable_modules/fable-library.3.6.2/Reflection.js";
import { Universal_Detail$2__get_isADND, ADND2nd_CharacterSheet, Universal_Detail$2__map2e_Z1FC644CA, DND5e_CharacterSheet, Universal_Detail$2__map5e_Z1D9544EA, Universal_Detail$2__converge_Z191A36BF, Universal_Detail$2$reflection, DND5e_CharacterSheet$reflection, ADND2nd_CharacterSheet$reflection } from "../../Lib/Character.fs.js";
import { Graveyard_write, PCs_write, Graveyard_read, PCs_read } from "./LocalStorage.fs.js";
import { Cmd_ofSub, Cmd_OfFunc_result, Cmd_batch } from "../fable_modules/Fable.Elmish.3.1.0/cmd.fs.js";
import { map as map_1, filter, cons, reverse, singleton, ofArray, empty } from "../fable_modules/fable-library.3.6.2/List.js";
import { getEnumerator, createObj, comparePrimitives, max, equals } from "../fable_modules/fable-library.3.6.2/Util.js";
import { ProgramModule_toNavigable, Navigation_modifyUrl, Navigation_newUrl } from "../fable_modules/Fable.Elmish.Browser.3.0.4/navigation.fs.js";
import { tryFind, append, map, fold } from "../fable_modules/fable-library.3.6.2/Array.js";
import { some, value as value_52 } from "../fable_modules/fable-library.3.6.2/Option.js";
import { thunk1, flip } from "../../Lib/Common.fs.js";
import { printf, toText, toConsole } from "../fable_modules/fable-library.3.6.2/String.js";
import { Interop_reactApi } from "../fable_modules/Feliz.1.61.0/Interop.fs.js";
import { createElement } from "react";
import { empty as empty_1, singleton as singleton_1, collect, append as append_1, delay, toList } from "../fable_modules/fable-library.3.6.2/Seq.js";
import { $007CInt$007C_$007C, $007CEnd$007C_$007C, $007CStr$007C_$007C, ParseArgs_Init_Z1A8FAE6B } from "../../Lib/Parsing.fs.js";
import { ProgramModule_mkProgram, ProgramModule_withSubscription, ProgramModule_run } from "../fable_modules/Fable.Elmish.3.1.0/program.fs.js";
import { Program_withReactBatched } from "../fable_modules/Fable.Elmish.React.3.0.1/react.fs.js";
import "../sass/main.sass";


export class App_Page extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Home", "Generate", "Adventure"];
    }
}

export function App_Page$reflection() {
    return union_type("UI.App.App.Page", [], App_Page, () => [[], [["Item", View_Model$reflection()]], [["Item", Model$reflection()]]]);
}

export class App_Model extends Record {
    constructor(current, currentUrl, error, roster, graveyard) {
        super();
        this.current = current;
        this.currentUrl = currentUrl;
        this.error = error;
        this.roster = roster;
        this.graveyard = graveyard;
    }
}

export function App_Model$reflection() {
    return record_type("UI.App.App.Model", [], App_Model, () => [["current", App_Page$reflection()], ["currentUrl", option_type(string_type)], ["error", option_type(string_type)], ["roster", array_type(Universal_Detail$2$reflection(ADND2nd_CharacterSheet$reflection(), DND5e_CharacterSheet$reflection()))], ["graveyard", array_type(Universal_Detail$2$reflection(ADND2nd_CharacterSheet$reflection(), DND5e_CharacterSheet$reflection()))]]);
}

export class App_Msg extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Error", "ClearError", "Transform", "ChargenMsg", "AdventureMsg", "Open", "GoHome", "Navigate", "UpdateUrl", "AddOrUpdateRoster", "ResumePlay", "ClearRoster", "DeleteCharacter"];
    }
}

export function App_Msg$reflection() {
    return union_type("UI.App.App.Msg", [], App_Msg, () => [[["msg", string_type]], [], [["Item", lambda_type(App_Model$reflection(), App_Model$reflection())]], [["Item", View_Msg$reflection()]], [["Item", Msg$reflection()]], [["Item1", App_Page$reflection()], ["url", option_type(string_type)]], [], [["url", string_type]], [["url", string_type]], [["Item1", Universal_Detail$2$reflection(ADND2nd_CharacterSheet$reflection(), DND5e_CharacterSheet$reflection())], ["stillAlive", bool_type]], [["id", int32_type]], [], [["id", int32_type]]]);
}

export function App_init(initialCmd) {
    return [new App_Model(new App_Page(0), void 0, void 0, PCs_read(), Graveyard_read()), Cmd_batch(initialCmd)];
}

export function App_chargenControl(dispatch, _arg1) {
    switch (_arg1.tag) {
        case 2: {
            dispatch(new App_Msg(6));
            break;
        }
        case 3: {
            const suffix = _arg1.fields[0];
            dispatch(new App_Msg(8, `chargen/${suffix}`));
            break;
        }
        case 1: {
            const character_1 = _arg1.fields[0];
            dispatch(new App_Msg(2, (m) => (new App_Model(new App_Page(2, init(character_1)), m.currentUrl, m.error, m.roster, m.graveyard))));
            dispatch(new App_Msg(8, "/"));
            break;
        }
        default: {
            const character = _arg1.fields[0];
            dispatch(new App_Msg(9, character, true));
            dispatch(new App_Msg(6));
        }
    }
}

export function App_update(msg, model) {
    let inputRecord;
    const model_1 = new App_Model(model.current, model.currentUrl, void 0, model.roster, model.graveyard);
    if (msg.tag === 1) {
        return [new App_Model(model_1.current, model_1.currentUrl, void 0, model_1.roster, model_1.graveyard), empty()];
    }
    else if (msg.tag === 2) {
        const f = msg.fields[0];
        return [(inputRecord = f(model_1), new App_Model(inputRecord.current, inputRecord.currentUrl, void 0, inputRecord.roster, inputRecord.graveyard)), empty()];
    }
    else if (msg.tag === 7) {
        const url = msg.fields[0];
        if (!equals(model_1.currentUrl, url)) {
            return [new App_Model(model_1.current, url, model_1.error, model_1.roster, model_1.graveyard), Navigation_newUrl("#" + url)];
        }
        else {
            return [model_1, empty()];
        }
    }
    else if (msg.tag === 8) {
        const url_1 = msg.fields[0];
        if (!equals(model_1.currentUrl, url_1)) {
            return [new App_Model(model_1.current, url_1, model_1.error, model_1.roster, model_1.graveyard), Navigation_modifyUrl("#" + url_1)];
        }
        else {
            return [model_1, empty()];
        }
    }
    else if (msg.tag === 9) {
        const characterSheet = msg.fields[0];
        const stillAlive = msg.fields[1];
        const getId = (sheet1) => Universal_Detail$2__converge_Z191A36BF(sheet1, (c) => c.id, (c_1) => c_1.id);
        const delete$ = (id$0027, collection) => collection.filter((r) => (!equals(getId(r), id$0027)));
        const addOrUpdate = (collection_1) => {
            let patternInput;
            const matchValue = getId(characterSheet);
            if (matchValue == null) {
                const id$0027_1 = 1 + fold((e1, e2) => max((x, y) => comparePrimitives(x, y), e1, e2), 0, map((arg) => value_52(getId(arg)), append(model_1.roster, model_1.graveyard), Int32Array));
                patternInput = [id$0027_1, Universal_Detail$2__map5e_Z1D9544EA(Universal_Detail$2__map2e_Z1FC644CA(characterSheet, (c_2) => (new ADND2nd_CharacterSheet(id$0027_1, c_2.name, c_2.origin, c_2.sex, c_2.Str, c_2.Dex, c_2.Con, c_2.Int, c_2.Wis, c_2.Cha, c_2.exceptionalStrength, c_2.originalRolls, c_2.hp, c_2.ac, c_2.attacks, c_2.toHitBonus, c_2.damage, c_2.xp, c_2.levels, c_2.traits, c_2.wealth))), (c_3) => (new DND5e_CharacterSheet(id$0027_1, c_3.name, c_3.origin, c_3.sex, c_3.Str, c_3.Dex, c_3.Con, c_3.Int, c_3.Wis, c_3.Cha, c_3.originalRolls, c_3.hp, c_3.ac, c_3.toHit, c_3.damage, c_3.xp, c_3.levels, c_3.traits, c_3.wealth)))];
            }
            else {
                const id = matchValue | 0;
                patternInput = [id, characterSheet];
            }
            const sheet = patternInput[1];
            const id$0027_2 = patternInput[0];
            return append([sheet], delete$(id$0027_2, collection_1));
        };
        if (stillAlive) {
            const roster$0027 = addOrUpdate(model_1.roster);
            PCs_write(roster$0027);
            return [new App_Model(model_1.current, model_1.currentUrl, model_1.error, roster$0027, model_1.graveyard), empty()];
        }
        else {
            const graveyard$0027 = addOrUpdate(model_1.graveyard);
            const id_1 = getId(characterSheet);
            const roster$0027_1 = delete$(id_1, model_1.roster);
            PCs_write(roster$0027_1);
            Graveyard_write(graveyard$0027);
            return [new App_Model(model_1.current, model_1.currentUrl, model_1.error, roster$0027_1, graveyard$0027), empty()];
        }
    }
    else if (msg.tag === 11) {
        const roster$0027_2 = new Array(0);
        PCs_write(roster$0027_2);
        return [new App_Model(model_1.current, model_1.currentUrl, model_1.error, roster$0027_2, model_1.graveyard), empty()];
    }
    else if (msg.tag === 12) {
        const id_2 = msg.fields[0] | 0;
        const roster$0027_3 = model_1.roster.filter((_arg1) => {
            if (_arg1.tag === 1) {
                const char_1 = _arg1.fields[0];
                return !equals(char_1.id, id_2);
            }
            else {
                const char = _arg1.fields[0];
                return !equals(char.id, id_2);
            }
        });
        PCs_write(roster$0027_3);
        return [new App_Model(model_1.current, model_1.currentUrl, model_1.error, roster$0027_3, model_1.graveyard), empty()];
    }
    else if (msg.tag === 6) {
        return [new App_Model(new App_Page(0), model_1.currentUrl, void 0, model_1.roster, model_1.graveyard), Cmd_OfFunc_result(new App_Msg(7, "/"))];
    }
    else if (msg.tag === 5) {
        if (msg.fields[1] == null) {
            const page_1 = msg.fields[0];
            return [new App_Model(page_1, model_1.currentUrl, model_1.error, model_1.roster, model_1.graveyard), empty()];
        }
        else {
            const page = msg.fields[0];
            const url_2 = msg.fields[1];
            return [new App_Model(page, model_1.currentUrl, model_1.error, model_1.roster, model_1.graveyard), Cmd_OfFunc_result(new App_Msg(7, url_2))];
        }
    }
    else if (msg.tag === 3) {
        const msg_6 = msg.fields[0];
        const matchValue_1 = model_1.current;
        if (matchValue_1.tag === 1) {
            const chargenModel = matchValue_1.fields[0];
            const cmd = (arg_1) => Cmd_OfFunc_result(new App_Msg(3, arg_1));
            const patternInput_1 = View_update((arg_2) => Cmd_OfFunc_result(new App_Msg(3, arg_2)), (arg_3) => Cmd_ofSub((y_2) => {
                flip((dispatch, _arg1_1) => {
                    App_chargenControl(dispatch, _arg1_1);
                }, arg_3, y_2);
            }), msg_6, chargenModel);
            const cmd_1 = patternInput_1[1];
            const chargenModel_1 = patternInput_1[0];
            return [new App_Model(new App_Page(1, chargenModel_1), model_1.currentUrl, model_1.error, model_1.roster, model_1.graveyard), cmd_1];
        }
        else {
            return [model_1, Cmd_OfFunc_result(new App_Msg(0, `Message '${msg_6}' not compatible with current page (${model_1.current}))`))];
        }
    }
    else if (msg.tag === 4) {
        const msg_13 = msg.fields[0];
        const matchValue_2 = model_1.current;
        if (matchValue_2.tag === 2) {
            const model$0027 = matchValue_2.fields[0];
            return [new App_Model(new App_Page(2, update(msg_13, model$0027)), model_1.currentUrl, model_1.error, model_1.roster, model_1.graveyard), empty()];
        }
        else {
            return [model_1, Cmd_OfFunc_result(new App_Msg(0, `Message '${msg_13}' not compatible with current page (${model_1.current}))`))];
        }
    }
    else if (msg.tag === 10) {
        const id_3 = msg.fields[0] | 0;
        const matchValue_3 = tryFind((_arg2) => {
            if (_arg2.tag === 1) {
                const c_5 = _arg2.fields[0];
                return equals(c_5.id, id_3);
            }
            else {
                const c_4 = _arg2.fields[0];
                return equals(c_4.id, id_3);
            }
        }, model_1.roster);
        if (matchValue_3 != null) {
            const character = matchValue_3;
            return [model_1, Cmd_OfFunc_result(new App_Msg(5, new App_Page(2, init(character)), `resume/${id_3}`))];
        }
        else {
            return [model_1, Cmd_OfFunc_result(new App_Msg(0, "There is no character with id #{id}"))];
        }
    }
    else {
        const msg_1 = msg.fields[0];
        toConsole(`
        ============================
        =========ERROR==============
        ${msg_1}
        ============================
        `);
        return [new App_Model(model_1.current, model_1.currentUrl, msg_1, model_1.roster, model_1.graveyard), empty()];
    }
}

export function App_view(model, dispatch) {
    let children_1, matchValue_1, msg_1;
    const class$0027 = (element, className, children) => element(ofArray([["className", className], ["children", Interop_reactApi.Children.toArray(Array.from(children))]]));
    const matchValue = model.current;
    if (model.error != null) {
        return class$0027((arg00) => createElement("div", createObj(arg00)), "errorMsg", ofArray([(children_1 = singleton(value_52(model.error)), createElement("div", {
            children: Interop_reactApi.Children.toArray(Array.from(children_1)),
        })), createElement("button", {
            children: "OK",
            onClick: (arg20$0040) => {
                thunk1(dispatch, new App_Msg(1), arg20$0040);
            },
        }), createElement("button", {
            children: "Start over",
            onClick: (arg20$0040_1) => {
                thunk1(dispatch, new App_Msg(6), arg20$0040_1);
            },
        })]));
    }
    else {
        switch (matchValue.tag) {
            case 1: {
                const model_1 = matchValue.fields[0];
                return createElement(View_view, {
                    model: model_1,
                    control: (_arg1) => {
                        App_chargenControl(dispatch, _arg1);
                    },
                    dispatch: (arg_2) => {
                        dispatch(new App_Msg(3, arg_2));
                    },
                });
            }
            case 2: {
                const adventure = matchValue.fields[0];
                const stillAlive = (char) => stillAlive_1(adventure, char);
                const control = (_arg1_1) => {
                    let tupledArg_1, tupledArg;
                    switch (_arg1_1.tag) {
                        case 1: {
                            const enumerator_1 = getEnumerator(reverse(cons(adventure.state.mainCharacter, adventure.state.allies)));
                            try {
                                while (enumerator_1["System.Collections.IEnumerator.MoveNext"]()) {
                                    const char_3 = enumerator_1["System.Collections.Generic.IEnumerator`1.get_Current"]();
                                    dispatch((tupledArg_1 = [char_3, stillAlive(char_3)], new App_Msg(9, tupledArg_1[0], tupledArg_1[1])));
                                }
                            }
                            finally {
                                enumerator_1.Dispose();
                            }
                            dispatch(new App_Msg(6));
                            break;
                        }
                        case 2: {
                            const msg = _arg1_1.fields[0];
                            dispatch(new App_Msg(0, msg));
                            break;
                        }
                        default: {
                            const hasAlreadyBeenSaved = (char_1) => Universal_Detail$2__converge_Z191A36BF(char_1, (c) => (c.id != null), (c_1) => (c_1.id != null));
                            const enumerator = getEnumerator(reverse(filter(hasAlreadyBeenSaved, cons(adventure.state.mainCharacter, adventure.state.allies))));
                            try {
                                while (enumerator["System.Collections.IEnumerator.MoveNext"]()) {
                                    const char_2 = enumerator["System.Collections.Generic.IEnumerator`1.get_Current"]();
                                    dispatch((tupledArg = [char_2, stillAlive(char_2)], new App_Msg(9, tupledArg[0], tupledArg[1])));
                                }
                            }
                            finally {
                                enumerator.Dispose();
                            }
                        }
                    }
                };
                return view(adventure, control, (arg_3) => {
                    dispatch(new App_Msg(4, arg_3));
                });
            }
            default: {
                return createElement("div", {
                    className: "homePage",
                    children: Interop_reactApi.Children.toArray([createElement("div", {
                        children: Interop_reactApi.Children.toArray([(matchValue_1 = model.error, (matchValue_1 == null) ? "Welcome to Shining Sword" : ((msg_1 = matchValue_1, msg_1)))]),
                        style: {
                            marginBottom: 10,
                        },
                    }), createElement("button", {
                        children: "Create a character",
                        onClick: (_arg1_2) => {
                            if ((model.roster.length === 0) ? true : Universal_Detail$2__get_isADND(model.roster[0])) {
                                dispatch(new App_Msg(5, new App_Page(1, View_init()), "chargen/adnd"));
                            }
                            else {
                                dispatch(new App_Msg(5, new App_Page(1, View_init()), "chargen/5e"));
                                dispatch(new App_Msg(3, new View_Msg(10, new View_Ruleset(1))));
                            }
                        },
                    }), class$0027((arg00_1) => createElement("div", createObj(arg00_1)), "growToFill", singleton(class$0027((arg00_2) => createElement("div", createObj(arg00_2)), "existingCharacters", toList(delay(() => append_1(collect((ch) => {
                        let patternInput;
                        if (ch.tag === 1) {
                            const char_5 = ch.fields[0];
                            patternInput = [char_5.name, char_5.id, "D\u0026D 5E", "flairDND5e"];
                        }
                        else {
                            const char_4 = ch.fields[0];
                            patternInput = [char_4.name, char_4.id, "AD\u0026D", "flairADND"];
                        }
                        const txt = patternInput[0];
                        const id = patternInput[1];
                        const flair = patternInput[2];
                        const cssClass = patternInput[3];
                        return append_1(singleton_1(createElement("span", {
                            children: flair,
                            className: cssClass,
                        })), delay(() => {
                            let arg_4;
                            return append_1(singleton_1(createElement("span", {
                                children: txt,
                                className: "characterName",
                                onClick: (arg_4 = (new App_Msg(10, value_52(id))), (arg20$0040_2) => {
                                    thunk1(dispatch, arg_4, arg20$0040_2);
                                }),
                            })), delay(() => {
                                let arg_5;
                                return append_1(singleton_1(createElement("button", {
                                    children: "Resume",
                                    className: "resumeCommand",
                                    onClick: (arg_5 = (new App_Msg(10, value_52(id))), (arg20$0040_3) => {
                                        thunk1(dispatch, arg_5, arg20$0040_3);
                                    }),
                                })), delay(() => {
                                    let arg_6;
                                    return singleton_1(createElement("button", {
                                        children: "Delete",
                                        className: "deleteCommand",
                                        onClick: (arg_6 = (new App_Msg(12, value_52(id))), (arg20$0040_4) => {
                                            thunk1(dispatch, arg_6, arg20$0040_4);
                                        }),
                                    }));
                                }));
                            }));
                        }));
                    }, model.roster), delay(() => ((model.roster.length > 0) ? singleton_1(createElement("button", {
                        children: "Delete all characters",
                        className: "deleteAllCommand",
                        onClick: (arg20$0040_5) => {
                            thunk1(dispatch, new App_Msg(11), arg20$0040_5);
                        },
                    })) : empty_1())))))))), createElement("div", {
                        className: "footer",
                        children: Interop_reactApi.Children.toArray([createElement("a", {
                            href: "https://www.flaticon.com/free-icons/sword",
                            children: "Sword icon created by pongsakornRed - Flaticon",
                        })]),
                    })]),
                });
            }
        }
    }
}

export function Url_Parse_locationParser(rootActivePattern, loc) {
    let tupledArg;
    const $007CRoot$007C_$007C = rootActivePattern;
    const matchValue = ParseArgs_Init_Z1A8FAE6B(loc.hash);
    let pattern_matching_result, v;
    const activePatternResult16042 = $007CStr$007C_$007C("#", matchValue[0], matchValue[1]);
    if (activePatternResult16042 != null) {
        const activePatternResult16043 = $007CRoot$007C_$007C(activePatternResult16042);
        if (activePatternResult16043 != null) {
            if (((tupledArg = activePatternResult16043[1], $007CEnd$007C_$007C(tupledArg[0], tupledArg[1]))) != null) {
                pattern_matching_result = 0;
                v = activePatternResult16043[0];
            }
            else {
                pattern_matching_result = 1;
            }
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
            return v;
        }
        case 1: {
            return empty();
        }
    }
}

export function Url_Parse_$007CPage$007C_$007C(_arg1_0, _arg1_1) {
    let tupledArg;
    const _arg1 = [_arg1_0, _arg1_1];
    const activePatternResult16064 = $007CStr$007C_$007C("chargen/adnd/DarkSun", _arg1[0], _arg1[1]);
    if (activePatternResult16064 != null) {
        const ctx = activePatternResult16064;
        const model$0027 = View_init();
        const cmd = ofArray([new App_Msg(5, new App_Page(1, model$0027), void 0), new App_Msg(3, new View_Msg(1, new View_ChargenMethod(3)))]);
        return [cmd, ctx];
    }
    else {
        const activePatternResult16062 = $007CStr$007C_$007C("chargen/adnd", _arg1[0], _arg1[1]);
        if (activePatternResult16062 != null) {
            const ctx_1 = activePatternResult16062;
            const model$0027_1 = View_init();
            const cmd_1 = singleton(new App_Msg(5, new App_Page(1, model$0027_1), void 0));
            return [cmd_1, ctx_1];
        }
        else {
            const activePatternResult16060 = $007CStr$007C_$007C("chargen/5e", _arg1[0], _arg1[1]);
            if (activePatternResult16060 != null) {
                const ctx_2 = activePatternResult16060;
                const model$0027_2 = View_init();
                const cmd_2 = ofArray([new App_Msg(5, new App_Page(1, model$0027_2), void 0), new App_Msg(3, new View_Msg(10, new View_Ruleset(1)))]);
                return [cmd_2, ctx_2];
            }
            else {
                const activePatternResult16058 = $007CStr$007C_$007C("chargen", _arg1[0], _arg1[1]);
                if (activePatternResult16058 != null) {
                    const ctx_3 = activePatternResult16058;
                    const model$0027_3 = View_init();
                    const cmd_3 = singleton(new App_Msg(5, new App_Page(1, model$0027_3), void 0));
                    return [cmd_3, ctx_3];
                }
                else {
                    let pattern_matching_result, ctx_4, id;
                    const activePatternResult16055 = $007CStr$007C_$007C("resume/", _arg1[0], _arg1[1]);
                    if (activePatternResult16055 != null) {
                        const activePatternResult16056 = $007CInt$007C_$007C(activePatternResult16055);
                        if (activePatternResult16056 != null) {
                            pattern_matching_result = 0;
                            ctx_4 = activePatternResult16056[1];
                            id = activePatternResult16056[0];
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
                            return [singleton(new App_Msg(10, id)), ctx_4];
                        }
                        case 1: {
                            let pattern_matching_result_1, ctx_5;
                            const activePatternResult16051 = $007CStr$007C_$007C("/", _arg1[0], _arg1[1]);
                            if (activePatternResult16051 != null) {
                                pattern_matching_result_1 = 0;
                                ctx_5 = activePatternResult16051;
                            }
                            else {
                                const activePatternResult16052 = $007CStr$007C_$007C("", _arg1[0], _arg1[1]);
                                if (activePatternResult16052 != null) {
                                    if (((tupledArg = activePatternResult16052, $007CEnd$007C_$007C(tupledArg[0], tupledArg[1]))) != null) {
                                        pattern_matching_result_1 = 0;
                                        ctx_5 = activePatternResult16052;
                                    }
                                    else {
                                        pattern_matching_result_1 = 1;
                                    }
                                }
                                else {
                                    pattern_matching_result_1 = 1;
                                }
                            }
                            switch (pattern_matching_result_1) {
                                case 0: {
                                    return [singleton(new App_Msg(6)), ctx_5];
                                }
                                case 1: {
                                    return void 0;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

export const Url_Parse_page = (loc) => Url_Parse_locationParser((tupledArg) => Url_Parse_$007CPage$007C_$007C(tupledArg[0], tupledArg[1]), loc);

export function Url_parse(loc) {
    const parsed = Url_Parse_page(loc);
    return map_1((msg) => Cmd_OfFunc_result(msg), parsed);
}

export function Url_unpack(cmds, model) {
    return [model, Cmd_batch(cmds)];
}

ProgramModule_run(Program_withReactBatched("feliz-app", ProgramModule_toNavigable((loc) => Url_parse(loc), (cmds, model_2) => Url_unpack(cmds, model_2), ProgramModule_withSubscription((m) => Cmd_ofSub((dispatch_1) => {
    window.onerror = ((msg_1) => {
        if ((toString(msg_1).indexOf("SocketProtocolError") >= 0) === false) {
            dispatch_1(new App_Msg(0, toText(printf("Error: %A"))(msg_1)));
            window.alert(some("Unhandled Exception: " + toString(msg_1)));
        }
    });
}), ProgramModule_mkProgram((initialCmd) => App_init(initialCmd), (msg, model) => App_update(msg, model), (model_1, dispatch) => App_view(model_1, dispatch))))));

//# sourceMappingURL=App.fs.js.map
