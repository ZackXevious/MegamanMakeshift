#!/bin/sh
mkdir -p ttf
echo "Creating PostScript fonts ..."
for font in sfd/*.[Ss][Ff][Dd] ; do
    fontforge ./font2ttf.ff "$font"
done
mv sfd/*.ttf ttf
