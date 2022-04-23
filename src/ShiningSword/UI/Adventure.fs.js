import { toString, Record, Union } from "../fable_modules/fable-library.3.6.2/Types.js";
import { record_type, list_type, option_type, union_type, string_type } from "../fable_modules/fable-library.3.6.2/Reflection.js";
import { deadly, hard, easy, embark, toOngoing, beginEncounter, finishAdventure, fightUntilFixedPoint, AdventureState, loadCharacters, downtime, AdventureState$reflection, AdventureSpec$reflection } from "../../Lib/Adventure.fs.js";
import { Universal_Detail$2__converge_Z191A36BF, Universal_Detail$2__get_isADND, Universal_Detail$2$reflection, DND5e_CharacterSheet$reflection, ADND2nd_CharacterSheet$reflection } from "../../Lib/Character.fs.js";
import { sortBy, ofArray, head, tail, last, append, singleton, empty, isEmpty, contains, cons, map } from "../fable_modules/fable-library.3.6.2/List.js";
import { PCs_read } from "./LocalStorage.fs.js";
import { partialApply, compareArrays, createObj, structuralHash, equals } from "../fable_modules/fable-library.3.6.2/Util.js";
import { thunk1, chooseRandom } from "../../Lib/Common.fs.js";
import { toList as toList_1, tryFind } from "../fable_modules/fable-library.3.6.2/Map.js";
import { acP, personalNameP, isFriendlyP, damageTakenP, hpP } from "../../Lib/Ribbit/Operations.fs.js";
import { value as value_38 } from "../fable_modules/fable-library.3.6.2/Option.js";
import { Interop_reactApi } from "../fable_modules/Feliz.1.61.0/Interop.fs.js";
import { createElement } from "react";
import { empty as empty_1, singleton as singleton_1, append as append_1, map as map_1, delay, toList } from "../fable_modules/fable-library.3.6.2/Seq.js";
import { View_viewCharacter } from "./Chargen.fs.js";

export class ControlMsg extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Save", "SaveAndQuit", "Error"];
    }
}

export function ControlMsg$reflection() {
    return union_type("UI.Adventure.ControlMsg", [], ControlMsg, () => [[], [], [["msg", string_type]]]);
}

export class Activity extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Downtime", "AdventureIntro", "Fighting", "Looting", "CompletingAdventure", "PushingUpDaisies"];
    }
}

export function Activity$reflection() {
    return union_type("UI.Adventure.Activity", [], Activity, () => [[], [], [], [], [], []]);
}

export class Msg extends Union {
    constructor(tag, ...fields) {
        super();
        this.tag = (tag | 0);
        this.fields = fields;
    }
    cases() {
        return ["Embark", "Recruit", "Proceed"];
    }
}

export function Msg$reflection() {
    return union_type("UI.Adventure.Msg", [], Msg, () => [[["Item", AdventureSpec$reflection()]], [["Item", Universal_Detail$2$reflection(ADND2nd_CharacterSheet$reflection(), DND5e_CharacterSheet$reflection())]], []]);
}

export class Model extends Record {
    constructor(activity, title, log, spec, state) {
        super();
        this.activity = activity;
        this.title = title;
        this.log = log;
        this.spec = spec;
        this.state = state;
    }
}

export function Model$reflection() {
    return record_type("UI.Adventure.Model", [], Model, () => [["activity", Activity$reflection()], ["title", option_type(string_type)], ["log", list_type(list_type(string_type))], ["spec", option_type(AdventureSpec$reflection())], ["state", AdventureState$reflection()]]);
}

export function recruitCompanions(model, control, dispatch) {
    const getId = (_arg1) => {
        if (_arg1.tag === 1) {
            const char_1 = _arg1.fields[0];
            return char_1.id;
        }
        else {
            const char = _arg1.fields[0];
            return char.id;
        }
    };
    const isADND = Universal_Detail$2__get_isADND(model.state.mainCharacter);
    const ineligibleIds = map(getId, cons(model.state.mainCharacter, model.state.allies));
    const candidates = PCs_read().filter((r) => {
        if (Universal_Detail$2__get_isADND(r) === isADND) {
            return !contains(getId(r), ineligibleIds, {
                Equals: (x, y) => equals(x, y),
                GetHashCode: (x) => structuralHash(x),
            });
        }
        else {
            return false;
        }
    });
    if (candidates.length === 0) {
        return control(new ControlMsg(2, isEmpty(model.state.allies) ? "No companions are available at this time. (Try creating more characters first.)" : "No more companions are available at this time. (Try creating more characters first.)"));
    }
    else {
        return dispatch(new Msg(1, chooseRandom(candidates)));
    }
}

export function stillAlive(adventure, char) {
    const ribbit = adventure.state.ribbit;
    const name = Universal_Detail$2__converge_Z191A36BF(char, (c) => c.name, (c_1) => c_1.name);
    const matchValue = tryFind(name, ribbit.roster);
    if (matchValue == null) {
        return true;
    }
    else {
        const id = matchValue | 0;
        return hpP["Domain.Ribbit.Property`1.Get"](id, ribbit) > damageTakenP["Domain.Ribbit.Property`1.Get"](id, ribbit);
    }
}

export function init(sheet) {
    const state = downtime(sheet);
    return new Model(new Activity(0), void 0, empty(), void 0, state);
}

export function update(msg, model) {
    if (msg.tag === 1) {
        const companion = msg.fields[0];
        const state$0027 = loadCharacters(singleton(companion), model.state);
        return new Model(model.activity, model.title, model.log, model.spec, new AdventureState(state$0027.mainCharacter, append(state$0027.allies, singleton(companion)), state$0027.currentEncounter, state$0027.scheduledEncounters, state$0027.ribbit));
    }
    else if (msg.tag === 2) {
        if (equals(model.activity, new Activity(2))) {
            const patternInput = fightUntilFixedPoint(model.state);
            const state$0027_1 = patternInput[2];
            const outcome = patternInput[0];
            const msgs = patternInput[1];
            const matchValue = [new Model(model.activity, model.title, cons(msgs, model.log), model.spec, state$0027_1), outcome];
            if (matchValue[1].tag === 0) {
                const model_1 = matchValue[0];
                return new Model(new Activity(3), "Victory!!! " + last(msgs), model_1.log, model_1.spec, model_1.state);
            }
            else if (matchValue[1].tag === 1) {
                const model_2 = matchValue[0];
                return new Model(new Activity(5), "You have been defeated!", model_2.log, model_2.spec, model_2.state);
            }
            else {
                const model_3 = matchValue[0];
                return model_3;
            }
        }
        else if (msg.tag === 2) {
            const matchValue_1 = model.state.scheduledEncounters;
            if (isEmpty(matchValue_1)) {
                if (equals(model.activity, new Activity(4))) {
                    return new Model(new Activity(0), void 0, model.log, model.spec, downtime(model.state.mainCharacter));
                }
                else if (isEmpty(matchValue_1)) {
                    const patternInput_1 = finishAdventure(value_38(model.spec), model.state);
                    const state$0027_2 = patternInput_1[1];
                    const msg_1 = patternInput_1[0];
                    return new Model(new Activity(4), msg_1, model.log, model.spec, state$0027_2);
                }
                else {
                    throw (new Error("Match failure"));
                }
            }
            else {
                const rest = tail(matchValue_1);
                const next = head(matchValue_1);
                return new Model(new Activity(2), next.description, model.log, model.spec, beginEncounter(toOngoing(next), rest, model.state));
            }
        }
        else {
            throw (new Error("Match failure"));
        }
    }
    else {
        const spec = msg.fields[0];
        const state = embark(spec, model.state.mainCharacter);
        return new Model(new Activity(1), spec.description, empty(), spec, state);
    }
}

export function class$0027(element, className, children) {
    return element(ofArray([["className", className], ["children", Interop_reactApi.Children.toArray(Array.from(children))]]));
}

export function statusSummary(creatures, isFriendly, columns, dispatch) {
    let children_2, children, children_4;
    return class$0027((arg00) => createElement("table", createObj(arg00)), "summaryTable", [(children_2 = singleton((children = toList(delay(() => map_1((column) => createElement("th", {
        children: [column.title],
    }), columns))), createElement("tr", {
        children: Interop_reactApi.Children.toArray(Array.from(children)),
    }))), createElement("thead", {
        children: Interop_reactApi.Children.toArray(Array.from(children_2)),
    })), (children_4 = toList(delay(() => map_1((creature) => class$0027((arg00_1) => createElement("tr", createObj(arg00_1)), isFriendly(creature) ? "friendly" : "enemy", toList(delay(() => map_1((column_1) => {
        const value_1 = column_1.render(creature);
        return createElement("td", {
            children: [value_1],
        });
    }, columns)))), creatures))), createElement("tbody", {
        children: Interop_reactApi.Children.toArray(Array.from(children_4)),
    }))]);
}

export function view(model, control, dispatch) {
    return class$0027((arg00) => createElement("div", createObj(arg00)), "adventure", toList(delay(() => append_1(View_viewCharacter(model.state.mainCharacter), delay(() => {
        let matchValue, title;
        return append_1((matchValue = model.title, (matchValue != null) ? ((title = matchValue, singleton_1(createElement("span", {
            children: title,
            className: "header",
        })))) : ((empty_1()))), delay(() => {
            let matchValue_1, recent;
            return append_1((matchValue_1 = [model.log, model.activity], (!isEmpty(matchValue_1[0])) ? ((matchValue_1[1].tag === 2) ? ((recent = head(matchValue_1[0]), singleton_1(class$0027((arg00_1) => createElement("div", createObj(arg00_1)), "logOutput", toList(delay(() => map_1((entry) => createElement("div", {
                children: Interop_reactApi.Children.toArray([entry]),
            }), recent))))))) : ((matchValue_1[1].tag === 3) ? ((recent = head(matchValue_1[0]), singleton_1(class$0027((arg00_1) => createElement("div", createObj(arg00_1)), "logOutput", toList(delay(() => map_1((entry) => createElement("div", {
                children: Interop_reactApi.Children.toArray([entry]),
            }), recent))))))) : ((matchValue_1[1].tag === 5) ? ((recent = head(matchValue_1[0]), singleton_1(class$0027((arg00_1) => createElement("div", createObj(arg00_1)), "logOutput", toList(delay(() => map_1((entry) => createElement("div", {
                children: Interop_reactApi.Children.toArray([entry]),
            }), recent))))))) : ((empty_1()))))) : ((empty_1()))), delay(() => {
                let ribbit, isFriendly, get$, getHP, rosterIds, columns;
                return append_1((!equals(model.activity, new Activity(0))) ? ((ribbit = model.state.ribbit, (isFriendly = ((id) => isFriendlyP["Domain.Ribbit.Property`1.Get"](id, ribbit)), (get$ = ((f, tupledArg) => {
                    const id_1 = tupledArg[1];
                    let copyOfStruct = f(id_1, ribbit);
                    return toString(copyOfStruct);
                }), (getHP = ((tupledArg_1) => {
                    const id_2 = tupledArg_1[1] | 0;
                    const hp = hpP["Domain.Ribbit.Property`1.Get"](id_2, ribbit) | 0;
                    const damage = damageTakenP["Domain.Ribbit.Property`1.Get"](id_2, ribbit) | 0;
                    if (damage === 0) {
                        return `${hp}`;
                    }
                    else {
                        return `${(hp - damage)}/${hp}`;
                    }
                }), (rosterIds = sortBy((_arg3) => {
                    const name_8 = _arg3[0];
                    const id_3 = _arg3[1] | 0;
                    const isFriendly_1 = isFriendly(id_3);
                    const isAlive = hpP["Domain.Ribbit.Property`1.Get"](id_3, ribbit) >= 0;
                    return [!isFriendly_1, !isAlive, id_3];
                }, toList_1(ribbit.roster), {
                    Compare: (x, y) => compareArrays(x, y),
                }), (columns = ofArray([{
                    render: partialApply(1, get$, [(arg00_6, arg10_4) => personalNameP["Domain.Ribbit.Property`1.Get"](arg00_6, arg10_4)]),
                    title: "Name",
                }, {
                    render: partialApply(1, get$, [(arg00_7, arg10_5) => acP["Domain.Ribbit.Property`1.Get"](arg00_7, arg10_5)]),
                    title: "AC",
                }, {
                    render: getHP,
                    title: "HP",
                }]), singleton_1(statusSummary(rosterIds, (arg) => isFriendly(arg[1]), columns, dispatch))))))))) : empty_1(), delay(() => singleton_1(class$0027((arg00_8) => createElement("div", createObj(arg00_8)), "finalize", toList(delay(() => {
                    const matchValue_2 = model.activity;
                    switch (matchValue_2.tag) {
                        case 1: {
                            return append_1(singleton_1(createElement("button", {
                                children: "Proceed",
                                onClick: (_arg4) => {
                                    dispatch(new Msg(2));
                                },
                            })), delay(() => singleton_1(createElement("button", {
                                children: "Recruit companions",
                                onClick: (_arg5) => {
                                    recruitCompanions(model, control, dispatch);
                                },
                            }))));
                        }
                        case 2: {
                            return singleton_1(createElement("button", {
                                children: "Fight!",
                                onClick: (_arg6) => {
                                    dispatch(new Msg(2));
                                },
                            }));
                        }
                        case 3: {
                            return append_1(singleton_1(createElement("button", {
                                children: "Continue onward",
                                onClick: (_arg7) => {
                                    dispatch(new Msg(2));
                                },
                            })), delay(() => singleton_1(createElement("button", {
                                children: "Call it a day",
                                onClick: (_arg8) => {
                                    control(new ControlMsg(1));
                                },
                            }))));
                        }
                        case 4: {
                            const finish = (_arg4_1) => {
                                if (stillAlive(model, model.state.mainCharacter)) {
                                    control(new ControlMsg(0));
                                    dispatch(new Msg(2));
                                }
                                else {
                                    control(new ControlMsg(1));
                                }
                            };
                            return singleton_1(createElement("button", {
                                children: "Finish",
                                onClick: finish,
                            }));
                        }
                        case 5: {
                            return singleton_1(createElement("button", {
                                children: "OK",
                                onClick: (arg20$0040_1) => {
                                    thunk1(control, new ControlMsg(1), arg20$0040_1);
                                },
                            }));
                        }
                        default: {
                            return append_1(singleton_1(createElement("button", {
                                children: "Go on an easy adventure",
                                onClick: (_arg1_1) => {
                                    dispatch(new Msg(0, easy()));
                                },
                            })), delay(() => append_1(singleton_1(createElement("button", {
                                children: "Go on a hard adventure",
                                onClick: (_arg2_1) => {
                                    dispatch(new Msg(0, hard()));
                                },
                            })), delay(() => append_1(singleton_1(createElement("button", {
                                children: "Go on a deadly adventure",
                                onClick: (_arg3_1) => {
                                    dispatch(new Msg(0, deadly()));
                                },
                            })), delay(() => singleton_1(createElement("button", {
                                children: "Save and quit",
                                onClick: (arg20$0040) => {
                                    thunk1(control, new ControlMsg(1), arg20$0040);
                                },
                            }))))))));
                        }
                    }
                }))))));
            }));
        }));
    })))));
}

//# sourceMappingURL=Adventure.fs.js.map
