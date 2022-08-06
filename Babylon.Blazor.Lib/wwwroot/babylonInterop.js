export function drawText(canvasId,x,y,text, fontText, colorText) {
    var babylonCanvas = document.getElementById(canvasId);
    var ctx = babylonCanvas.getContext('2d');
    if (colorText) {
        ctx.fillStyle = colorText;
    }
    if (fontText) {
        ctx.font = fontText;
    }
    ctx.fillText(text, x,y);
}

export function createTestScene(canvasId) {
    var babylonCanvas = document.getElementById(canvasId);
    /// <var>The engine</var>
    var engine = new BABYLON.Engine(babylonCanvas, true);

    engine.runRenderLoop(function () {
        /// <summary>
        /// </summary>
        scene.render();
    });
    
    window.addEventListener("resize", function () {
        /// <summary>
        /// </summary>
        engine.resize();
    });

    /// <var>The scene</var>
    var scene = new BABYLON.Scene(engine);

    /// <var>The camera</var>
    var camera = new BABYLON.ArcRotateCamera("Camera", Math.PI / 2, Math.PI / 2, 2, new BABYLON.Vector3(0, 0, 5), scene);
    camera.attachControl(canvas, true);

    /// <var>The light1</var>
    var light1 = new BABYLON.HemisphericLight("light1", new BABYLON.Vector3(1, 1, 0), scene);
    /// <var>The light2</var>
    var light2 = new BABYLON.PointLight("light2", new BABYLON.Vector3(0, 1, -1), scene);

    /// <var>The sphere</var>
    var sphere = BABYLON.MeshBuilder.CreateSphere("sphere", { diameter: 2 }, scene);

    return scene;
};

//createEngine
export function createEngine(canvasId, antialias) {
    var babylonCanvas = document.getElementById(canvasId);
    if (babylonCanvas == null) {
        alert("canvas id '" + canvasId + "' is not found");
    }
    //TraceProps("*canvas*", babylonCanvas);
    //console.log(babylonCanvas, typeof (babylonCanvas), babylonCanvas.clientWidth, babylonCanvas.clientHeight);
    /// <var>The canvas parent</var>
    var canvasParent = babylonCanvas.parentNode;
    //TraceProps("*canvas parent *", canvasParent);
    //console.log(canvasParent, typeof (canvasParent), canvasParent.clientWidth, canvasParent.clientHeight, canvasParent.height);
    babylonCanvas.width = canvasParent.clientWidth;
    babylonCanvas.height = canvasParent.clientHeight;
    /// <var>The engine</var>
    var engine = new BABYLON.Engine(babylonCanvas, antialias);
    //assert(babylonCanvas.width);
    engine.resize();
    //engine.setSize(babylonCanvas.clientWidth, babylonCanvas.cleintHeight,true);
    //console.log(engine, engine.RenderingContext, typeof (engine.id), window.clientWidth, window.cleintHeight);
    //TraceProps("*engine*", engine);

    window.addEventListener("resize", function () {
        //console.log("--resize--");
        //console.log(babylonCanvas, typeof (babylonCanvas), babylonCanvas.clientWidth, babylonCanvas.cleintHeight);
        //console.log(canvasParent, typeof (canvasParent), canvasParent.clientWidth, canvasParent.cleintHeight, canvasParent.height);
        //console.log(engine, engine.id, typeof (engine.id), window.clientWidth, window.cleintHeight);
        /// <summary>
        /// </summary>
        babylonCanvas.width = canvasParent.clientWidth;
        babylonCanvas.height = canvasParent.clientHeight;
        engine.resize();
    });
    //alert(babylonEngine);
    //TraceProps("*engine*",engine);
    
    //var scene = new BABYLON.Scene(engine);
    //alert(scene);

    return engine;
}

export function createScene(engine) {
    //alert(engine);
   
    return new BABYLON.Scene(engine);
}

export function createVector3(x,y,z) {
    return new BABYLON.Vector3(x, y, z);
}

export function createColor3(x, y, z) {
    return new BABYLON.Color3(x, y, z);
}

export function createColor4(r, g, b, a) {
    //alert(r + ", " + g + ", " + b + ", " + a);
    return new BABYLON.Color4(r, g, b, a);
}

export function createFaceColors(r, g, b, a) {
    var colors = new Array(6);

    for (let i = 0; i < 6; i++) {
        colors[i] = new BABYLON.Color4(r, g, b, a);
    }
    TraceProps("*colors for face*", colors, true);
    return colors;
}

export function createArcRotateCamera (name, alpha, beta, radius, target, scene, canvasId) {
    var camera = new BABYLON.ArcRotateCamera(name, alpha, beta, radius, target, scene);
    /// <var>The canvas</var>
    var canvas = document.getElementById(canvasId);
    camera.attachControl(canvas, true);
    //camera.wheelDeltaPercentage = 0.01;??
    //----autorotate
    //camera.useAutoRotationBehavior = true;
    //camera.autoRotationBehavior.idleRotationSpeed = 1;
    ////camera.idleRotationSpinupTime = 300;
    return camera;
}

export function setAutoRotate(camera, useAutoRotate, idleRotationSpeed) {
    if (useAutoRotate) {
        camera.useAutoRotationBehavior = true;
        camera.autoRotationBehavior.idleRotationSpeed = idleRotationSpeed;
    } else {
        camera.useAutoRotationBehavior = false;
    }
}

export function createHemisphericLight(name, direction, intensity, scene) {
    var light = new BABYLON.HemisphericLight(name, direction, scene);
    light.intensity = intensity;
    return light;
}

export function createPointLight(name, direction, intensity, scene) {
    var light = new BABYLON.PointLight(name, direction, scene);
    light.intensity = intensity;
    return light;
}

export function createSphere(name, options, rotation, position, scene) {
    //alert("createSphere1");
    //TraceProps("*spere.options*",options);
    var mesh = BABYLON.MeshBuilder.CreateSphere(name, options, scene);
    if (rotation) {
        mesh.rotation = rotation;
    }
    if (position) {
        //alert(name);
        //alert(position);
        //TraceProps("*spere.position*", position);
        mesh.position = position;
    }
    //TraceProps("*sphere-" + name + "*", mesh, false);
    //TraceProps("*sphere-" + name + ".position*", mesh.position, false);
    return mesh;
}

export function сreateCylinder (name, options, rotation, position, scene) {
    //alert(options);123
    //alert("сreateCylinder2");
    var mesh = BABYLON.MeshBuilder.CreateCylinder(name, options, scene);
    if (rotation) {
        mesh.rotation = rotation;
    }
    if (position) {
        mesh.position = position;
    }
    //mesh.position.x = 2.125;
    //alert(mesh);
    return mesh;
}

export function createBox(name, options, rotation, position, faceColors, scene) {
    //alert(options); 
    //alert("сreateBox");
    
    //TraceProps("*createBox.options input*", options, true);
    //TraceProps("*faceColors*", faceColors, true);
    if (faceColors && options) {
        options.faceColors = faceColors;
    }
    //TraceProps("*createBox.options*", options, true);
    var mesh = BABYLON.MeshBuilder.CreateBox(name, options, scene);
    if (rotation) {
        mesh.rotation = rotation;
    }
    if (position) {
        mesh.position = position;
    }
    //alert(mesh);
    return mesh;
}

export function createTorus(name, options, rotation, position, scene) {
    //alert(options); test1
    //alert("сreateBox");
    var mesh = BABYLON.MeshBuilder.CreateTorus(name, options, scene);
    if (rotation) {
        mesh.rotation = rotation;
    }
    if (position) {
        mesh.position = position;
    }
    //alert(mesh);
    return mesh;
}
export function createTube(name, fromPoint, toPoint, radius, scene) {
    var path = [fromPoint, toPoint];

    /// <var>The tube</var>
    var tube = BABYLON.MeshBuilder.CreateTube(name, { path: path, radius: radius }, scene);
    return tube;
}

export function createMaterial(name, scene, diffuseColor, emissiveColor, alpha) {
    var mat = new BABYLON.StandardMaterial(name, scene);
    //mat.diffuseColor = new BABYLON.Color3(0.5, 0.6, 0.9);
    //mat.emissiveColor = new BABYLON.Color3(0.1, 0.1, 0.2);
    //mat.alpha = 0.2;
    if (diffuseColor) {
        mat.diffuseColor = diffuseColor;
    }
    if (emissiveColor) {
        mat.emissiveColor = emissiveColor;
    }
    if (alpha) {
        mat.alpha = alpha;
    }
    mat.metallic = 1.0;
    //TraceProps("*mat*",mat);
    return mat;
}

export function setMaterial(mesh, mat) {
    //alert(x);
    //alert(mesh);

    mesh.material = mat;
    return mesh;
}
export function setMaterialTexture(material, texture) {
    material.diffuseTexture = texture;
    //material.albedoTexture = texture;
    //material.diffuseTexture.uOffset = -0.1;
    //material.diffuseTexture.vOffset = 0.1;
    //material.diffuseTexture.uScale = 2;
    //material.diffuseTexture.vScale = 2;
    //material.invertNormalMapX = true;
    //material.invertNormalMapY = true;
    //material.bumpTexture = texture;
    //material.diffuseTexture.vScale = 1;
}

export function runRenderLoop (engine, scene) {
    engine.runRenderLoop(function () {
        scene.render();
    });
}

export function createGrid(sizeX, sizeY, step,color) {
    console.log("createGrid");
    /// <var>My lines</var>
    var myLines = [];

    //const step = 0.1;
    //const sizeX = 5;
    //const sizeY = 5;
    /// <var>The actual size x</var>
    var actualSizeX;
    /// <var>The actual size y</var>
    var actualSizeY;
    for (let x = 0; x < sizeY/step; x++) {
        actualSizeX = sizeX;
        if (x % 10 === 0) {
            actualSizeX += step;
        }
        myLines.push([new BABYLON.Vector3(0, x * step, 0), new BABYLON.Vector3(actualSizeX, x * step, 0)]);
    }
    for (let y = 0; y < sizeX / step; y++) {
        actualSizeY = sizeX;
        if (y % 10 === 0) {
            actualSizeY += step;
        }
        myLines.push([new BABYLON.Vector3(y * step, 0, 0), new BABYLON.Vector3(y * step, actualSizeY,  0)]);
    }

    //Create linesystem
    const linesystem = BABYLON.MeshBuilder.CreateLineSystem("linesystem", { lines: myLines });
    //linesystem.color = new BABYLON.Color3(0, 1, 0);
    linesystem.color = color;
    //var myLines2 = [];
    //myLines2.push([new BABYLON.Vector3(0, 1, 0), new BABYLON.Vector3(3, 4, 0)]);
    //myLines2.push([new BABYLON.Vector3(0.5, 0.5, 0), new BABYLON.Vector3(3.5, 3.5, 0)]);
    //myLines2.push([new BABYLON.Vector3(1, 0, 0), new BABYLON.Vector3(4, 3, 0)]);

    //const linesystem2 = BABYLON.MeshBuilder.CreateLineSystem("linesystem2", { lines: myLines2 });
    //linesystem2.color = new BABYLON.Color3(1, 0, 0);
}

export function createTextPlane (scene, position, text, color, size) {
    var dynamicTexture = new BABYLON.DynamicTexture("DynamicTexture", 50, scene, true);
    dynamicTexture.hasAlpha = true;
    dynamicTexture.drawText(text, 5, 40, "bold 36px Arial", color, "transparent", true);
    /// <var>The plane</var>
    var plane = new BABYLON.Mesh.CreatePlane("TextPlane", size, scene, true);
    plane.material = new BABYLON.StandardMaterial("TextPlaneMaterial", scene);
    plane.material.backFaceCulling = false;
    plane.material.specularColor = new BABYLON.Color3(0, 0, 0);
    plane.material.diffuseTexture = dynamicTexture;
    plane.position = position;
    //TraceProps("*textPlane*", plane);
    return plane;
};

//Not universal function. Create text texture for a sphere
export function createTextTexture(scene, text, width, height, fontAsText, colorAsText) {
    var texture = new BABYLON.DynamicTexture("dynamic texture", { width: width, height: height }, scene);
    //console.log("*$*",width, height);
    //alert("xaxa");
    //Add text to dynamic texture
    //var fontAsText = "bold 30px monospace";
    //Y=30..120
    texture.drawText(text, 45, height / 2, fontAsText, "black", colorAsText, true);
    //texture.drawText(text + "1", 5, 130, fontAsText, "black", "transparent", true);
    texture.drawText(text, 170, height / 2, fontAsText, "black", "transparent", true);
    //texture.drawText(text + "3", 60, 60, fontAsText, "black", "red", true);
    //texture.drawText(text + "4", 80, 80, fontAsText, "black", "red", true);
    //texture.drawText(text + "5", 100, 100, fontAsText, "black", "red", true);
    texture.hasAlpha = true;
    return texture;
    //return null;
}

//string name, string url, int capacity, int width, int height
export function сreateSpriteManager(name, url, capacity, width, height, scene) {
    var spriteManager = new BABYLON.SpriteManager(name, url, capacity, { width: width, height: height }, scene);
    //var spriteManager = new BABYLON.SpriteManager("treesManager", "https://i.ibb.co/mSpjhgh/Lampe.png", 200, { width: 51, height: 98 }, scene);

    //console.log("*createSpriteManager", spriteManager, url, width, height);
    return spriteManager;
}

export function сreateSprite(name, spriteManager) {
    var sprite = new BABYLON.Sprite(name, spriteManager);

    //console.log("*сreateSprite", sprite, spriteManager, spriteManager);
    return sprite;
}

export function playAnimation(fromKey, toKey, isInLoop, startDelay, onAnimationEndObjectReference, sprite) {
    try {
        sprite.playAnimation(fromKey, toKey, isInLoop, startDelay, function () {
            //called without sprite loop
            //console.log("*playAnimation loop finished", onAnimationEndObjectReference);
            onAnimationEndObjectReference.invokeMethodAsync('Babylon.Blazor', 'UpdateMessageCaller');
            onAnimationEndObjectReference.dispose();
        });
        //console.log("*playAnimation", sprite);
    } catch (err) {
        console.log(err);
    } 
}

export function setPickable(pickable, sprite) {
    try {
        sprite.isPickable = pickable;
    } catch (err) {
        console.log(err);
    }
}

export function setPosition(position, sprite) {
    try {
        sprite.position = position;
    } catch (err) {
        console.log(err);
    }
}

export function setInvert(invertU,invertV, sprite) {
    try {
        sprite.invertU = invertU;
        sprite.invertV = invertV;
    } catch (err) {
        console.log(err);
    }
}

export function setSize(height, width, sprite) {
    try {
        sprite.height = height;
        sprite.width = width;
    } catch (err) {
        console.log(err);
    }
}

export function setFrameNumber(frameNumber, sprite) {
    try {
        sprite.cellIndex = frameNumber;
    } catch (err) {
        console.log(err);
    }
}

export function setAngle(angle, sprite) {
    try {
        sprite.angle = angle;
    } catch (err) {
        console.log(err);
    }
}
export function showWorldAxis(size,scene) {
    var makeTextPlane = function (text, color, size) {
        var dynamicTexture = new BABYLON.DynamicTexture("DynamicTexture", 50, scene, true);
        dynamicTexture.hasAlpha = true;
        dynamicTexture.drawText(text, 5, 40, "bold 36px Arial", color, "transparent", true);
        /// <var>The plane</var>
        var plane = BABYLON.Mesh.CreatePlane("TextPlane", size, scene, true);
        plane.material = new BABYLON.StandardMaterial("TextPlaneMaterial", scene);
        plane.material.backFaceCulling = false;
        plane.material.specularColor = new BABYLON.Color3(0, 0, 0);
        plane.material.diffuseTexture = dynamicTexture;
        return plane;
    };
    /// <var>The axis x</var>
    var axisX = BABYLON.Mesh.CreateLines("axisX", [
        BABYLON.Vector3.Zero(), new BABYLON.Vector3(size, 0, 0), new BABYLON.Vector3(size * 0.95, 0.05 * size, 0),
        new BABYLON.Vector3(size, 0, 0), new BABYLON.Vector3(size * 0.95, -0.05 * size, 0)
    ], scene);
    axisX.color = new BABYLON.Color3(1, 0, 0);
    /// <var>The x character</var>
    var xChar = makeTextPlane("X", "red", size / 10);
    xChar.position = new BABYLON.Vector3(0.9 * size, -0.05 * size, 0);
    /// <var>The axis y</var>
    var axisY = BABYLON.Mesh.CreateLines("axisY", [
        BABYLON.Vector3.Zero(), new BABYLON.Vector3(0, size, 0), new BABYLON.Vector3(-0.05 * size, size * 0.95, 0),
        new BABYLON.Vector3(0, size, 0), new BABYLON.Vector3(0.05 * size, size * 0.95, 0)
    ], scene);
    axisY.color = new BABYLON.Color3(0, 1, 0);
    /// <var>The y character</var>
    var yChar = makeTextPlane("Y", "green", size / 10);
    yChar.position = new BABYLON.Vector3(0, 0.9 * size, -0.05 * size);
    /// <var>The axis z</var>
    var axisZ = BABYLON.Mesh.CreateLines("axisZ", [
        BABYLON.Vector3.Zero(), new BABYLON.Vector3(0, 0, size), new BABYLON.Vector3(0, -0.05 * size, size * 0.95),
        new BABYLON.Vector3(0, 0, size), new BABYLON.Vector3(0, 0.05 * size, size * 0.95)
    ], scene);
    axisZ.color = new BABYLON.Color3(0, 0, 1);
    /// <var>The z character</var>
    var zChar = makeTextPlane("Z", "blue", size / 10);
    zChar.position = new BABYLON.Vector3(0, 0.05 * size, 0.9 * size);
};
//-------------------------------------------------------------------------------------------------
const isObject = (obj) => {
    return Object.prototype.toString.call(obj) === '[object Object]';
};

function TraceProps(name, obj, recursive) {
    /// <summary>
    /// Traces the props.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="obj">The object.</param>
    /// <param name="recursive">The recursive.</param>
    console.log(name + " - type:" + typeof(obj));
    for (var key in obj) {
        if (obj.hasOwnProperty(key)) {
            var item = obj[key];
            if (recursive && isObject(item)) {
                TraceProps("\t" + key,item);
            } else {
                console.log(key + " -> " + item);
            }
        }
    }
}

