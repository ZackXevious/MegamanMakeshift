#!/bin/sh
mkdir -p otf
echo "Creating PostScript fonts ..."
for font in ttf/*.[Tt][Tt][Ff] ; do
    fontforge ./font2otf.ff "$font"
done
mv ttf/*.otf otf
