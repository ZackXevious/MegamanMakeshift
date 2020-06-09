#!/bin/sh
mkdir -p ttf
echo "Creating PostScript fonts ..."
for font in pfb/*.pfb ; do
    fontforge ./font2ttf.ff "$font"
done
for font in pfb/*.PFB ; do
    fontforge ./font2ttf.ff "$font"
done
mv pfb/*.ttf ttf
