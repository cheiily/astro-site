import fs from 'fs';

function readFiles(dirname, onFileContent, onProperty) {
    let files = fs.readdirSync(dirname);
    onProperty("amt", files.length);
    fs.readdirSync(dirname).filter(filename => {
        return filename.endsWith(".json");
    }).forEach(filename => {
        onFileContent(filename, fs.readFileSync(dirname + filename, 'utf-8'));
    });
}

// export const prerender = false;
export function GET({params, request}) {
    let dict = {};
    let dataArr = [];
    let path = "dist/api/sscnotif/";
    // let path = "public/api/sscnotif/";

    let filterhead = request.headers.get("filter");
    let filter = filterhead == 1 || filterhead == undefined;
    dict["filter"] = filter;

    let counter = 0;
    let fn = filter ? (filename, content) => {
        let json = JSON.parse(content);
        if (json["draft"]) return;
        if (json["validdays"] > 0 && (Date.now() - (new Date(json["posttime"]).getTime()) < json["validdays"] * 24 * 60 * 60 * 1000)) return;
        dataArr.push(json);
        counter++;
    } : (filename, content) => {
        dataArr.push(JSON.parse(content));
    };

    readFiles(path, fn, (propKey, propVal) => {
        dict[propKey] = propVal;
    })
    dict["data"] = dataArr;
    if (filter) dict["amt"] = counter;

    return new Response(JSON.stringify(dict), {
        headers: {
            "Content-Type": "application/json"
        }
    });
}