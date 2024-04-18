var secondaryActivity = "FerrousScrap,NonFerrousScrap,Others";

var secondaryActivityFerrous = "A,B,C,D";

var secondaryActivityNonFerrous = "P,Q,R,S";

var secondaryActivityStainless = "X,Y,Z";

var secondaryActivityOthers = "sample";

// splitting
var mainCategory = secondaryActivity.split(",");

var subCategory = [secondaryActivityFerrous.split(","), secondaryActivityNonFerrous.split(","), secondaryActivityStainless.split(",")];

var result = "";
for (i=0; i < mainCategory.lenth; i++) {
    result += mainCategory[i] + " = "+ subCategory[i]
}

console.log(result);
