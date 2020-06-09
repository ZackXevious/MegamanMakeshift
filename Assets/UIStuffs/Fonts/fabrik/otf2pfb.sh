#!/bin/sh
mkdir -p pfb
echo "Creating PostScript fonts ..."
for font in otf/*.otf ; do
    fontforge ./font2pfb.ff "$font"
done
mv otf/*.pfb pfb
mv otf/*.afm pfb
