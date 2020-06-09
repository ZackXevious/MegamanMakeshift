#!/bin/sh
mkdir -p ttf
echo "Creating PostScript fonts ..."
for font in otf/*.otf ; do
    fontforge ./font2ttf.ff "$font"
done
mv otf/*.ttf ttf
