#!/bin/sh
mkdir -p otf
echo "Creating PostScript fonts ..."
for font in sfd/*.[Ss][Ff][Dd] ; do
    fontforge ./font2otf.ff "$font"
done
mv sfd/*.otf otf
