import tailwind from "@astrojs/tailwind";
import { defineConfig } from "astro/config";

import mdx from "@astrojs/mdx";
import sitemap from "@astrojs/sitemap";
import pagefind from "astro-pagefind";

import netlify from "@astrojs/netlify";

// https://astro.build/config
export default defineConfig({
  site: "http://cheily.one",
  integrations: [tailwind(), sitemap(), mdx(), pagefind()],

  markdown: {
    shikiConfig: {
      theme: "css-variables",
    },
  },

  // adapter: netlify(),
});