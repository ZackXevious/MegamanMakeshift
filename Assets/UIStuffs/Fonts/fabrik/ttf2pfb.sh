#!/bin/sh
mkdir -p pfb
echo "Creating PostScript fonts ..."
for font in ttf/*.[Tt][Tt][Ff] ; do
    fontforge ./font2pfb.ff "$font"
done
mv ttf/*.pfb pfb
mv ttf/*.afm pfb
